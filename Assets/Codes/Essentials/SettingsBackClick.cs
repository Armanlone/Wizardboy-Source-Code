using UnityEngine;
using Game.LevelManagement;
using UnityEngine.Events;

namespace Essentials
{

    ///<summary> If 'Back' is clicked, player goes back to Main Menu if in Scene 01. Otherwise, player goes back to In-game UI.
    /// And closes the Settings.</summary>
    public class SettingsBackClick : MonoBehaviour
    {

        [SerializeField]
        private UnityEvent goBackMainMenu = new UnityEvent();

        [Space]

        [SerializeField]
        private UnityEvent goBackInGameUI = new UnityEvent();
        
        public void ChooseWhereToGoBack()
        {

            if (LevelManager.getCurrentSceneBuildIndex() == LevelManager.getLastSceneBuildIndex())
            {
                print("Close Settings, open Main Menu.");
                goBackMainMenu?.Invoke();
            }

            else
            {
                print("Close Settings, open In-game UI.");
                goBackInGameUI?.Invoke();
            }
        
        }

    }


}
