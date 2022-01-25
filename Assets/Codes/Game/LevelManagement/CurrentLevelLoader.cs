using UnityEngine;


namespace Game.LevelManagement
{

    ///<summary> Class that Loads a level. </summary>

    public class CurrentLevelLoader : MonoBehaviour
    {

        ///<summary> Loads the current level. </summary>
        public void Load()
        {
            LevelManager.LoadLevel(LevelManager.getCurrentSceneBuildIndex());
        }

    }

}