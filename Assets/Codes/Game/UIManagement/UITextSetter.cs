using UnityEngine;
using UnityEngine.UI;
using Mechanics;

namespace Game.UIManagment
{
    
    ///<summary> Set text of UI through code. </summary>
    // Change this code when game is finished.
        
    public class UITextSetter : MonoBehaviour
    {
        
        [SerializeField]
        private CountdownTimer countdownTimer = null;

        [SerializeField]
        private Text text = null;

        private void Update()
        {

            if (text == null || countdownTimer == null)
            {
                return;
            }

            else
            {
                //INSTANCE.game.txtScore.text = score.ToString();
                text.text = ((int) countdownTimer.getTimeLimit).ToString();

            }

        }

    }


}
