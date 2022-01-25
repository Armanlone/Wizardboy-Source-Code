using UnityEngine;

namespace Game.UIManagement
{

    ///<summary>
    /// Activates / deactivates a flashing white image.
    ///</summary>

    public class UIFlashActivator : MonoBehaviour
    {
        
        public void Activate(bool isActive) => UIManager.getFlash().SetActive(isActive);

    }


}