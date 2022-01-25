using UnityEngine;


namespace Game.LevelManagement
{

    ///<summary> Class that loads the main menu. </summary>

    public class MainMenuLoader : MonoBehaviour
    {

        ///<summary> Loads the main menu. </summary>
        public void Load()
        {

            LevelManager.LoadLevel(LevelManager.getLastSceneBuildIndex());

        }

    }

}