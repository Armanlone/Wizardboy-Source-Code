using UnityEngine;
using Game;
using Platformer2DMechanics.PhysicsObject;

namespace Platformer2DMechanics.CharacterControl
{

    ///<summary>
    /// Objects can move with this when attached.
    ///</summary>

    public class Movement : MonoBehaviour
    {

        [Tooltip("Will it calculate the gravity at update?")]
        [SerializeField]
        private bool calculateGravityAtUpdate = false;

        [Tooltip("Attach the Platformer2D reference here.")]
        public Platformer2D platformer2D = null;

        [Space]

        // Walking or moving attributes of the object attached to.
        [Header("Walking")]
        
        [Tooltip("How FAST it can walk.")]
        [SerializeField]
        [Range(1f, 15f)]
        private float speed = 6f;

        [Tooltip("Multiplier for slipping.")]
        [SerializeField]
        [Range(1f, 5f)]
        private float slippingMultiplier = 3f;

        #region Jump Variables

        // Jumping attributes of the object attached to.
        [Header("Jumping")]
        
        [Tooltip("How HIGH it can jump.")]
        [SerializeField]
        [Range(1f, 10f)]
        private float highJump = 4f;

        [Tooltip("How LOW it can jump.")]
        [SerializeField]
        [Range(0.1f, 5f)]
        private float lowJump = 1f;

        [Tooltip("The time it takes to reach the top of the jump.")]
        [SerializeField]
        [Range(0.1f, 1f)]
        private float timeReachTop = 0.4f;

        // Coyote Time is the time it can stand still after leaving the platform. See Loony Tunes for other examples.
        [Header("Coyote Time")]
        
        [Tooltip("Can jump before touching the ground first.")]
        [SerializeField]
        [Range(0.1f, 1f)]
        private float groundedTime = 0.2f;

        [Tooltip("Can jump after jumping or leaving off the ground.")]
        [SerializeField]
        [Range(0.1f, 1f)]
        private float jumpTime = 0.2f;

        private float currentJumpTime = 0f, currentGroundedTime = 0f;
        private float highJumpVelocity = 0f, lowJumpVelocity = 0f;

        #endregion

        private Vector2 input, velocity;
        private float velocityDamping = 0f, gravity = -10f;

        private void Start()
        {
            if (!calculateGravityAtUpdate)
                CalculateGravity();
        }

        private void Update()
        {

            if(Game.GameManager.getIsGamePause())
                return; 

            if (calculateGravityAtUpdate)
                CalculateGravity();

            CalculateVelocity();
            GroundedTimeBuffer();
            CoyoteTimeBuffer();

            if (platformer2D == null)
                return;
            
            else
            {
                platformer2D.Move(velocity * Time.deltaTime);

                // Not affected by gravity if airborne or on ground.
                if (platformer2D.raycastCollisions.above || platformer2D.raycastCollisions.below)
                    velocity.y = 0;

            }
        
        }

        #region Methods for WALKING.

        public void SetInput(Vector2 input) => this.input = input;

        private void CalculateVelocity()
        {

            // Slip on ice platforms.
            float acceleration = (!platformer2D.raycastCollisions.isOnIce) ? input.x * speed : input.x * speed * slippingMultiplier;
            velocity.x = CalculateDampHorizontalVelocity(acceleration);
            velocity.y += gravity * Time.deltaTime;

        }

        private float CalculateDampHorizontalVelocity (float acceleration)
        {
            return Mathf.SmoothDamp(velocity.x, acceleration, ref velocityDamping, (platformer2D.raycastCollisions.below) ? 0.1f : 0.2f);
        }

        #endregion

        #region  Methods for JUMPING.

        private void CalculateGravity()
        {

            gravity = -(2 * highJump) / Mathf.Pow(timeReachTop, 2);
            highJumpVelocity = Mathf.Abs(gravity) * timeReachTop;
            lowJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * lowJump);
        
        }

        // Player will JUMP LOW.
        public void OnJumpInputUp()
        {

            if (velocity.y > lowJumpVelocity)
                velocity.y = lowJumpVelocity;

        }

        // Player will JUMP HIGH.
        public void OnJumpInputDown() => currentJumpTime = jumpTime;

        // BUFFER TIME for GROUNDED state of player.
        private void GroundedTimeBuffer()
        {

            currentGroundedTime -= Time.deltaTime;
            if (platformer2D.raycastCollisions.below)
                currentGroundedTime = groundedTime;

        }

        // BUFFER TIME for the player to JUMP OFF LEDGE.
        private void CoyoteTimeBuffer()
        {

            currentJumpTime -= Time.deltaTime;
            if (currentJumpTime > 0)
            {

                if (currentGroundedTime > 0)
                {
                    velocity.y = highJumpVelocity;
                    currentGroundedTime = 0f;
                }

                currentJumpTime = 0;

            }

        }

        #endregion

        public Vector2 getInput()
        {
            return this.input;
        }
        
    }

}