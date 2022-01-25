using UnityEngine;
using UnityEngine.Events;

namespace Game.ControlsManagement
{

    ///<summary>
    /// Press a key to do something.
    ///</summary>

    public class KeyPressOnUpdate : MonoBehaviour
    {
        
        [Tooltip("Key to press to do the things.")]
        [SerializeField]
        private KeyCode keyToPress = KeyCode.None;

        [Space]

        [Tooltip("Things to do when key pressed.")]
        [SerializeField]
        private UnityEvent onPress = new UnityEvent();

	//new bool
	[SerializeField]
        private bool needsToCheckPlayMode = false;

        // Just press a key to do the things, even if it's "KeyCode.None".
        private void Update()
        {

            if (keyToPress == KeyCode.None)
            {
                
                if (Input.anyKeyDown)
                    onPress?.Invoke();

            }

            else
            {
                
                if (Input.GetKeyDown(keyToPress))
		{

			if (needsToCheckPlayMode && !GameManager.getIsGamePause() && !GameManager.getIsGameOver()  && !GameManager.getIsLevelClear())
				onPress?.Invoke();
			
			else if (!needsToCheckPlayMode)
				onPress?.Invoke();

		}

            }
            
        }

    }

}