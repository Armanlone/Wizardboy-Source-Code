using UnityEngine;
using Game;
using Game.SpriteAnimation;
using Game.ControlsManagement;

namespace Platformer2DMechanics.CharacterControl
{
    
    ///<summary>
    /// Script for the players.
    /// NOTE: Optimized for rebinding the keys using ControlsManager.
    ///</summary>

    [RequireComponent(typeof(Movement))]

    public class PlayableCharacter : MonoBehaviour
    {

        [Tooltip("Attach the Movement reference here.")]
        [SerializeField]
        private Movement movement = null;

        [Tooltip("Attach the Animations reference here.")]
        [SerializeField]
        private Animations animations = null;

        [Tooltip("Attach the Sprite Flipper reference here.")]
        [SerializeField]
        private SpriteFlipper spriteFlipper = null;

        [Space]

        [Tooltip("Can the character jump?")]
        private bool canJump = true;

        [Tooltip("Button for walking.")]
        [SerializeField]
        private string buttonWalk = "Movement";

        [Tooltip("Button for jumping.")]
        [SerializeField]
        private string buttonJump = "Jump";

        private const string MOVEMENT_ARROW_KEYS = "MovementArrowKeys", MOVEMENT_WASD = "MovementWASD";

        /*[Tooltip("SFX time delay.")]
        [SerializeField]
        private float timeDelay = 1f;*/

        // If the objects are empty, try to get the components attached in this gameObject.
        private void Awake()
        {

            if (movement == null)
                movement = GetComponent<Movement>();

            if (animations == null)
                animations = GetComponent<Animations>();

            if (spriteFlipper == null)
                spriteFlipper = GetComponent<SpriteFlipper>();

        }

        private void Update()
        {

            if (GameManager.getIsGamePause() || GameManager.getIsGameOver())
                return;

            #region Movement and Animations

            if (movement == null)
                return;
            
            else
            {
                
                //Vector2 input = new Vector2(Input.GetAxisRaw("Walk"), 0f);
                Vector2 input = Vector2.zero;

                if (ControlsManager.GetKey(buttonWalk) != KeyCode.D)
                {
                    print("Keycode Right Arrow");
                    input = new Vector2(Input.GetAxisRaw(MOVEMENT_ARROW_KEYS), 0f);
                }

                else
                {
                    print("Keycode D");
                    input = new Vector2(Input.GetAxisRaw(MOVEMENT_WASD), 0f);
                }

                movement.SetInput(input);

                // Test script for SFX Walk.

                /*timeDelay -= Time.deltaTime;
                if (input.x != 0)
                {
                    if (timeDelay > 0)
                    {
                        
                        AudioManager.PlayAudioWithRandomPitch(17);
                        timeDelay = 0;
                    
                    }
                
                }*/

                // -------------------------

                if (string.IsNullOrEmpty(buttonJump) || !canJump)
                    return;

                else
                {

                    /*if (Input.GetButtonUp(buttonJump) && canJump)
                        movement.OnJumpInputUp();
                        

                    if (Input.GetButtonDown(buttonJump) && canJump)
                        movement.OnJumpInputDown();
                    */

                    if (Input.GetKeyUp(ControlsManager.GetKey(buttonJump))  && canJump)
                        movement.OnJumpInputUp();

                    if (Input.GetKeyDown(ControlsManager.GetKey(buttonJump)) && canJump)
                        movement.OnJumpInputDown();
                    
                }

                if (animations == null)
                    return;

                else
                {

                    // Animate walking.
                    float absWalkVelo = Mathf.Abs(input.x);
                    animations.Animate("walkVelocity", absWalkVelo);

                    // Animate on ground.
                    bool isOnGround = movement.platformer2D.raycastCollisions.below;
                    animations.Animate("isOnGround", isOnGround);

                }

                if (spriteFlipper == null)
                    return;

                else
                {

                    // Sprite flip.
                    bool isFacingLeft = movement.platformer2D.raycastCollisions.facingDirection == -1;
                    spriteFlipper.FlipHorizontal(isFacingLeft);

                }

            }
            
            #endregion

        }
        
    }

}