using UnityEngine;
using Game.DebugManagement;

namespace Game.ControlsManagement
{

    ///<summary>
    /// Handles all the keyboard inputs to control the user, and the key.
    ///</summary>

    public class ControlsManager : MonoBehaviour
    {

        #region Singleton
        
        private static ControlsManager INSTANCE = null;

        private void Awake()
        {
            
            if (INSTANCE != null && INSTANCE != this)
            {

                Destroy(gameObject);
                return;

            }

            INSTANCE = this;

            DontDestroyOnLoad(gameObject);

            DebugManager.ShowDebug("Controls Manager created.");

        }

        #endregion

        [Tooltip("Key used in the game.")]
        public Key[] keys;

        // Switches the old key to a new key.
        public static void RebindKey(Key newKey)
        {

            if (INSTANCE == null)
                return;

            for (int i = 0; i < INSTANCE.keys.Length; i++)
            {
                
                if (string.Equals(newKey.keyName, INSTANCE.keys[i].keyName))
                {
                    INSTANCE.SetKeyCode(INSTANCE.keys[i], newKey.keyCode);
                    INSTANCE.SetKeyID(INSTANCE.keys[i], newKey.keyID);
                    break;
                }

            }

        }

        // Sets the key's keycode to a new keycode.
        private void SetKeyCode(Key key, KeyCode newKeyCode)
        {

            if (newKeyCode == KeyCode.None)
            {
                Debug.Log("No key found.");
                return;
            }

            key.keyCode = newKeyCode;
            Debug.Log("Key: " + key.keyName);

        }

        // Sets the key's ID to a new one.
        private void SetKeyID(Key key, int newKeyID)
        {

            if (newKeyID <= -1)
                return;

            key.keyID = newKeyID;
            Debug.Log("Key: " + key.keyName + " New Key ID: " + key.keyID);

        }

        // Gets the certain key.
        public static KeyCode GetKey(string keyName)
        {

            for (int i = 0; i < INSTANCE.keys.Length; i++)
            {
                
                if (string.Equals(keyName, INSTANCE.keys[i].keyName))
                {
                    return INSTANCE.keys[i].keyCode;
                }

            }

            print("No key found.");
            return KeyCode.None;

        }

        public static int GetKeyID(string keyName)
        {

            for (int i = 0; i < INSTANCE.keys.Length; i++)
            {
                
                if (string.Equals(keyName, INSTANCE.keys[i].keyName))
                {
                    return INSTANCE.keys[i].keyID;
                }

            }

            print("No key found.");
            return -1;

        }

    }

}