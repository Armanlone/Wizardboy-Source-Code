using UnityEngine;
using UnityEngine.Events;
using Game;

namespace Game.ControlsManagement
{

    ///<summary>
    /// Release key from pressing.
    ///</summary>

    public class KeyPressRelease : MonoBehaviour
    {
        
        [Tooltip("Key to press to do the things.")]
        [SerializeField]
        private Key keyToRelease = null;

        [Space]

        [Tooltip("Things to do when key pressed.")]
        [SerializeField]
        private UnityEvent onRelease = new UnityEvent();

        // Just press a key to do the things, even if it's "KeyCode.None".
        private void Update()
        {

            if (Input.GetKeyUp(ControlsManager.GetKey(keyToRelease.keyName)) && !GameManager.getIsGamePause() && !GameManager.getIsGameOver() && !GameManager.getIsLevelClear())
                    onRelease?.Invoke();
                    
        }

    }

}