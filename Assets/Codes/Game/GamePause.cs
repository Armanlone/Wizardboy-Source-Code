using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    
    ///<summary>
    /// Pause/Unpause the game.
    ///</summary>

    public class GamePause : MonoBehaviour
    {

        [Tooltip("0 = Freeze time | 1 = Not freeze time")]
        [SerializeField]
        private bool setTimeScaleTo0 = false;

        [SerializeField]
        private UnityEvent onPause = new UnityEvent();

        ///<summary> Manually pause/unpause the game. </summary>
        public void Pause(bool pause)
        {

            GameManager.setIsGamePause(pause);
            //Time.timeScale = (pause && setTimeScaleTo0) ? 0 : 1;

            if (setTimeScaleTo0 && pause)
                Time.timeScale = 0;
                
            onPause?.Invoke();
        
        }

    }

}