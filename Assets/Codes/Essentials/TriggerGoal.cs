using UnityEngine;
using UnityEngine.Events;
using Game;

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
                    onTrigger?.Invoke();
                    isCollideable = false;
                    // Save system to do.
                }

            }

        }

    }

}