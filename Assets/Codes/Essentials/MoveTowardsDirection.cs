using UnityEngine;
using DG.Tweening;

namespace Essentials
{

    ///<summary>
    /// IMPORTANT TO NOTE: 
    /// Needs to have <code> using DG.Tweening </code> or HoTween from Unity Asset Store imported or it won't work. 
    /// Moves object to a specified direction.
    ///<summary>

    public class MoveTowardsDirection : MonoBehaviour
    {

        [SerializeField]
        private Direction direction = Direction.Up;
        
        [Tooltip("Attach the object's transform in order to move it.")]
        [SerializeField]
        private Transform _transform = null;

        [Tooltip("The value of where it will end.")]
        [SerializeField]
        private float endValue = 5f;

        [Tooltip("Time it takes to end.")]
        [SerializeField]
        private float duration = 2f;

        [Tooltip("Would you like it to snap like 24fps?")]
        [SerializeField]
        private bool wouldItSnap = false;

        // Moves the gameobject.
        public void Move()
        {

            if (_transform == null)
                return;

            switch (direction)
            {
                
                case Direction.Up:
                case Direction.Down:

                    _transform.DOMoveY(endValue, duration, wouldItSnap); 
                    break;

                case Direction.Left:
                case Direction.Right:

                    _transform.DOMoveX(endValue, duration, wouldItSnap);
                    break;

            }

        }

    }

}