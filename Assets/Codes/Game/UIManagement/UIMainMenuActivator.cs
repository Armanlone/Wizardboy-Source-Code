using UnityEngine;

namespace Game.UIManagement
{

    ///<summary> Activate/deactivate main menu. </summary>

    public class UIMainMenuActivator : MonoBehaviour
    {

        public bool isActivate = true;
        
        public void Activate()
        {
            UIManager.getMainMenu().SetActive(isActivate);
        }

    }


}
