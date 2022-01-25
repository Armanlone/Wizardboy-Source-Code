using UnityEngine;
using UnityEngine.Events;
using Game;
using UnityEngine.UI;

namespace Mechanics
{
    
    ///<summary>
    /// A countdown timer.
    ///</summary>
        
    public class CountdownTimer : MonoBehaviour
    {
        
        [Tooltip("The max limit of the countdown.")]
        [SerializeField]
        private float timeLimit = 100f;

        [Tooltip("How fast the countdown ticks?")]
        [SerializeField]
        private float speedUpMultiplier = 4f;

        [Tooltip("A key for pressing the rewind.")]
        [SerializeField]
        private KeyCode keyRewind = KeyCode.Space;

        [SerializeField]
        private Text text = null;

        [SerializeField]
        private Color _color = Color.white;

        [Tooltip("On Inspector, can can click this to restart the timer again.")]
        [SerializeField]
        private bool isRestart = false;

        [Tooltip("On Inspector, can see this if user is pressing a key.")]
        [SerializeField]
        private bool isPressingSpace = false;

        [SerializeField]
        private UnityEvent onCountdownEnd = new UnityEvent();

        // The original time limit to be used in restarting.
        private float origTimeLimit = -1f;

        private bool triggerOnce = true;

        // Game is in play mode (not in over or pause or player has key)
        private bool isGameInPlayMode = true;

        [Tooltip("Will the time count down?")]
        [SerializeField]
        private bool isCountDown = true;

        private void Start() => origTimeLimit = timeLimit;

        private void Update()
        {

            if (GameManager.getIsGamePause())
            {
                return;
            }

            isPressingSpace = Input.GetKey(keyRewind);

            isGameInPlayMode = !GameManager.getIsLevelClear() && !GameManager.getIsGameOver() && !GameManager.getIsGamePause();


            if (isPressingSpace && isGameInPlayMode)
            {
                timeLimit -= Time.deltaTime * speedUpMultiplier;
                text.color = _color;
            }
        
            else
            {
                if (isCountDown)
                    timeLimit -= Time.deltaTime;
                text.color = Color.white;
            }

            if (timeLimit <= 0)
            {
                timeLimit = 0;
                
                if (triggerOnce)
                {
                    onCountdownEnd?.Invoke();
                    triggerOnce = false;
                }

            }

            //Debug.Log("Remaining Time: " + timeLimit);

            if (isRestart)
            {
                timeLimit = origTimeLimit;
                isRestart = false;
                triggerOnce = true;
            }

        }

        #region Getter(s)    
        
        public float getTimeLimit => this.timeLimit;

        #endregion

    }

}