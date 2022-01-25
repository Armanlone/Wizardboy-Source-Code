using UnityEngine;

namespace Game.UIManagement
{
    
    ///<summary>
    /// Enables / disables the rewind glitch animation.
    ///</summary>

    public class UIGlitchEnabler : MonoBehaviour
    {
        
        public void Enable(bool isEnable)
        {

            // Prevent enabling when game is paused / over.
             if (GameManager.getIsGamePause() || GameManager.getIsGameOver() || GameManager.getIsLevelClear())
                isEnable = false;
            
            UIManager.getRewindGlitch().SetActive(isEnable);


        }


    }

}
