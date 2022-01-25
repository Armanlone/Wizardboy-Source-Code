using UnityEngine;

namespace Game.AudioManagement
{

    ///<summary>
    /// A mini-class for fading in/out an audio.
    ///</summary>

    public class AudioFade : MonoBehaviour
    {

        public int audioID = -1;

        public Fade fadeType = Fade.FadeIn;
        
        // Fades the audio.
        public virtual void FadeAudio()
        {

            if (audioID <= -1)
                return;

            else if (fadeType == Fade.FadeIn)
            {
                AudioManager.FadeIn(0.5f, audioID);
            }

            else
            {
                AudioManager.FadeOut(0.5f, audioID);
            }

        }

    }

}