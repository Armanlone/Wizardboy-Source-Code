using UnityEngine;
using UnityEngine.UI;

namespace Game.UIManagement
{
    ///<summary>
    /// Changes text of the UI. 
    ///</summary>
    public class UITextChanger : MonoBehaviour
    {
        
        public Text _text = null;

        public string newTextMessage = string.Empty;

        // Changes the text if called.
        public void ChangeText()
        {

            if (string.IsNullOrEmpty(newTextMessage))
                Debug.Log("Please insert a new message.");

            else
            {
                _text.text = newTextMessage;
            }

        }

    }

}