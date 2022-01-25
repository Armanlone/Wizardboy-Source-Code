using UnityEngine;


namespace Game.LevelManagement
{

    ///<summary> Loads next level base from current level index. </summary>

    public class NextLevelLoader : MonoBehaviour
    {

        // Calls the LevelManager to load the next scene.
        public void Load() => LevelManager.LoadLevel(LevelManager.getCurrentSceneBuildIndex() + 1);

    }

}