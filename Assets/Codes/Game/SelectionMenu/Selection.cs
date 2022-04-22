using UnityEngine;
using Game.SaveSystemManagement;

namespace Game.SelectionMenu
{
    
    ///<summary>
    /// Gameboy Selection: Navigating and selecting in the menu through buttons. (Up, Down, and Select)
    /// NOTE: This script is reconfigured to support the button clicking.
    ///</summary>

    public class Selection : MonoBehaviour
    {

        [Tooltip("The starting index in selection.")]
        [SerializeField]
        private int startingIndex = -1;

        [Tooltip("The size of the items in selection.")]
        [SerializeField]
        private int itemsSize = -1;

        //The current index in the selection.
        public int pointer { private set; get; }

        [Tooltip("The keyname for saving the pointer.")]
        [SerializeField]
        private string keyName = null;

        private void OnEnable()
        {
            pointer = SaveSystemManager.getIntData(keyName);
            Debug.LogWarning("Currently selected item: " + pointer);
        }

        // Point the pointer to the starting index.
        private void Start()
        {
            pointer = startingIndex;
            Debug.LogWarning("Currently selected item: " + pointer);
        }

        // The upward selection: 4 - 3 - 2 - 1 - ...
        public void ClickPrevious()
        {

            pointer--;

            if (pointer < 1)
            {
                pointer = itemsSize;
            }

            Debug.LogWarning("Currently selected item: " + pointer);

        }

        // The downward selection: 1 - 2 - 3 - 4 - ...
        public void ClickNext()
        {

            pointer++;

            if (pointer > itemsSize)
            {
                pointer = startingIndex;
            }

            Debug.LogWarning("Currently selected item: " + pointer);

        }

        public void SavePointer()
        {
            SaveSystemManager.setSaveData(keyName, pointer);
        }

        public void DeletePointer()
        {
            SaveSystemManager.setSaveData(keyName, 0);
        }

    }

}