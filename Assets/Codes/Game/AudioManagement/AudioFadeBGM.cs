using UnityEngine;

namespace Game.AudioManagement
{

    ///<summary>
    /// Necessary for the Restart button.
    /// Searches the audio: BGM type and fades it.
    ///</summary>

    public class AudioFadeBGM : AudioFade
    {

        public override void FadeAudio()
        {

            audioID = AudioManager.FindBGMAudioID();
            fadeType = Fade.FadeOut;
            
            base.FadeAudio();
        }
    
    }

}