using UnityEngine;

namespace Game.UIManagement
{

    ///<summary>
    /// Activates/deactivates transition.
    ///</summary>
        
    public class UITransitionActivator : MonoBehaviour
    {

        [Tooltip("Will it activate the UI Transition?")]
        [SerializeField]
        private bool willActivate = false;
        
        // Activates/deactivates transition.
        public void Activate()
        {
            
            if (UIManager.getTransition() == null)
                return;

            else
            {
                UIManager.getTransition().SetActive(willActivate);
                Debug.Log("Activate");
            }

        }


    }

}