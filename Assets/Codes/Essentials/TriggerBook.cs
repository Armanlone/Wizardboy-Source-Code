using UnityEngine;
using UnityEngine.Events;
using Game.UIManagement;

namespace Essentials
{

    ///<summary> Triggers the book when colliding, otherwise not. </summary>

    public class TriggerBook : MonoBehaviour
    {

        [Tooltip("The tag name of the Player.")]
        [SerializeField]
        private string tagPlayer = "Player";
       
        private bool isPlayerColliding = false;

        [Space]

        [SerializeField]
        private UnityEvent onStayTrigger = new UnityEvent();

        [Space]
        [SerializeField]
        private UIFader uIFadeIn = null, uIFadeOut = null;

        private void OnTriggerStay2D(Collider2D collision)
        {
            
            if (collision.CompareTag(tagPlayer))
            {
                isPlayerColliding = true;
                uIFadeIn.Fade();
            }

            if (isPlayerColliding)
            {
                onStayTrigger?.Invoke();
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {

            if (collision.CompareTag(tagPlayer))
            {
                isPlayerColliding = false;
                uIFadeOut.Fade();
            }

        }

    }

}