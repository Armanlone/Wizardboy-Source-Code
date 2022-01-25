using UnityEngine;

namespace Game.UIManagement
{

    ///<summary>
    /// Activates/deactivates Title Screen through code.
    ///</summary>

    public class  UITitleScreenActivator : MonoBehaviour
    {
        
        public void Activate(bool isActive) =>  UIManager.getTitleScreen().SetActive(isActive);

    }

}