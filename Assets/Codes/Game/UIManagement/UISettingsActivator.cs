using UnityEngine;

namespace Game.UIManagement
{

    ///<summary>
    /// Activates/deactivates Settings UI through code.
    ///</summary>

    public class UISettingsActivator : MonoBehaviour
    {
        
        public void Activate(bool isActive) =>  UIManager.getSettings().SetActive(isActive);

    }

}