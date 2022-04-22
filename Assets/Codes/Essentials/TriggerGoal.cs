using UnityEngine;
using UnityEngine.Events;
using Game;
using Game.LevelManagement;

public class TriggerGoal : MonoBehaviour
{

    [Tooltip("Key to activate goal.")]
    [SerializeField]
    private KeyCode keyActivateGoal = KeyCode.DownArrow;

    [Tooltip("The tag name of the gameObject that will collide.")]
    [SerializeField]
    private string tagName = string.Empty;
    
    [SerializeField]
    private UnityEvent onTrigger = new UnityEvent();

    [Space]

    [Tooltip("The level index of the current level.")]
    [SerializeField]
    private int levelIndex = 1;
    
    [Tooltip("Does this level has a question to answer before proceeding to the next level?")]
    [SerializeField]
    private bool doesCurrentLevelHasQuestion = false;

    [SerializeField]
    private UnityEvent onTriggerDirectUnlock = new UnityEvent();

    private bool isCollideable = true;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (string.IsNullOrEmpty(tagName) || !isCollideable)
        {
            return;
        }

        if (collision.CompareTag(tagName))
        {

            if (Input.GetKeyDown(keyActivateGoal))
            {

                if (GameManager.getIsLevelClear())
                {

                    print("Unlocked Levels: " + PlayerPrefs.GetInt(LevelManager.getLevelsUnlockedKey()));

                    // If the saved level of the player is higher than this level. In other words...
                    // If this level has a questions, and...
                    // If the player already passed this level, and only replaying this level. 
                    // Or the player already cleared the game before.
                    if (doesCurrentLevelHasQuestion && 
                        (PlayerPrefs.GetInt(LevelManager.getLevelsUnlockedKey()) > levelIndex || 
                            (PlayerPrefs.GetInt(LevelManager.getLevelsUnlockedKey()) == 10) && (levelIndex == 10)))
                    {
                        onTriggerDirectUnlock?.Invoke();
                        return;
                    }

                    else
                        onTrigger?.Invoke();
                    
                    isCollideable = false;
                    // Save system to do.

                    
                }

            }

        }

    }

}