using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    
    ///<summary>
    /// Game over...
    ///</summary>

    public class GameOver : MonoBehaviour
    {

        [SerializeField]
        private bool isGameOver = true;

        [SerializeField]
        private UnityEvent onGameOver = new UnityEvent();

        ///<summary> Game is over. </summary>
        public void Over()
        {

            if (!isGameOver)
                return;

            GameManager.setIsGameOver(isGameOver);
            onGameOver?.Invoke();

        }

    }

}