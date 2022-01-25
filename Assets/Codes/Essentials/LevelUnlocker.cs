using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{

    [Tooltip("The index of the new level unlocked.")]
    [SerializeField]
    private int newLevelUnlockedIndex = 1;

    private const string LEVELS_UNLOCKED_KEY = "levelsUnlocked";

    ///<summary> Save the level. </summary>
    public void Save()
    {

        if (newLevelUnlockedIndex < PlayerPrefs.GetInt(LEVELS_UNLOCKED_KEY, 1))
        {
            return;
        }

        PlayerPrefs.SetInt(LEVELS_UNLOCKED_KEY, newLevelUnlockedIndex);
        Debug.Log("Game Save Level: " + newLevelUnlockedIndex);
    }

}
