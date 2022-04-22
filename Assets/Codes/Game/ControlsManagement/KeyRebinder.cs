using UnityEngine;

namespace Game.ControlsManagement
{

    ///<summary>
    /// Handles all the keyboard inputs to control the user, and the key.
    ///</summary>

    public class KeyRebinder : MonoBehaviour
    {

        public Key rebindKey = null;

        public void Rebind()
        {

            if (string.IsNullOrEmpty(rebindKey.keyName))
                return;

            ControlsManager.RebindKey(rebindKey);

        }


    }

}