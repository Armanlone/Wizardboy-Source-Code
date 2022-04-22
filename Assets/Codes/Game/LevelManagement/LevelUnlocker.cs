using UnityEngine;

namespace Game.LevelManagement
{

    ///<summary>
    /// Saves the level, and unlocks the next level.
    ///</summary>
    public class LevelUnlocker : MonoBehaviour
    {

        [Tooltip("The index of the new level unlocked.")]
        [SerializeField]
        private int newLevelUnlockedIndex = 1;

        ///<summary> Save the level. </summary>
        public void Save()
        {

            if (newLevelUnlockedIndex < PlayerPrefs.GetInt(LevelManager.getLevelsUnlockedKey(), 1))
            {
                return;
            }

            PlayerPrefs.SetInt(LevelManager.getLevelsUnlockedKey(), newLevelUnlockedIndex);
            Debug.Log("Game Save Level: " + newLevelUnlockedIndex);
        }

    }

}

