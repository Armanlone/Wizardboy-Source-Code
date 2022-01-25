// Fade In and Out are from this source: https://forum.unity.com/threads/logarithmic-fade-out-and-in.438953/

using UnityEngine;
using System.Collections;

namespace Game.AudioManagement
{
    
    ///<summary>
    /// This manager handles all the audio-related in the game.
    ///</summary>

    public class AudioManager : MonoBehaviour
    {
        private static AudioManager INSTANCE = null;

        public Audio[] audios;

        private bool isMute = false;

        private void Awake()
        {

            if (INSTANCE != null && INSTANCE != this)
            {
                Destroy(gameObject);
                return;
            }

            INSTANCE = this;

            DontDestroyOnLoad(gameObject);

            Debug.Log("Audio Manager created.");
        }

        // Initialize the AudioSource and its components at Start.
        private void Start()
        {

            for(int i = 0; i < audios.Length; i++)
            {

                audios[i].id = i + 1;

                audios[i].source = gameObject.AddComponent<AudioSource>();

                audios[i].source.clip = audios[i].clip;

                audios[i].source.volume = audios[i].volume.value;
                audios[i].source.pitch = audios[i].pitch.value;

                audios[i].source.loop = audios[i].isLoop;

                audios[i].source.playOnAwake = false;

                audios[i].volume.setStoredValue(audios[i].volume.value);
                audios[i].pitch.setStoredValue(audios[i].pitch.value);

            }

        }

        #region Plays the Audio.

        // Plays the particular Audio.
        public static void PlayAudio(int id)
        {

            if (INSTANCE == null)
                return;

            Audio a = INSTANCE.FindAudio(id);

            if (a == null)
                return;

            a.source.volume = a.volume.getStoredValue();
            a.source.Play();

        }

        // Plays the particular Audio with adjustable pitch.
        public static void PlayAudioWithAdjustablePitch(int id, float desiredPitch)
        {

            if (INSTANCE == null)
                return;

            Audio a = INSTANCE.FindAudio(id);

            if (a == null)
                return;

            else
            {

                // Play the audio with adjusted pitch.
                a.source.pitch = desiredPitch;
                a.source.Play();
                
                // Reset the pitch.
                a.source.pitch = a.pitch.getStoredValue();

            }

        }

        // Plays an audio with randomized pitch.
        public static void PlayAudioWithRandomPitch(int id)
        {

            if (INSTANCE == null)
                return;

            else
            {

                //float minRange = -1, maxRange = 1;
                //float randomPitch = Random.Range(minRange, maxRange);
                Audio audio = INSTANCE.FindAudio(id);
                float randomPitch = Random.Range(audio.pitch.minValue, audio.pitch.maxValue);
                PlayAudioWithAdjustablePitch(id, randomPitch);

            }

        }

        /// <summary> Plays a random audio through a set of indeces given. </summary>
        public static void PlayRandomAudio(int[] IDs)
        {

            if (INSTANCE == null)
                return;

            int randomIndex = Random.Range(0, IDs.Length);

            int pickRandomAudioID = IDs[randomIndex]; print(randomIndex);

            PlayAudio(pickRandomAudioID);

        }

        // Mutes or Unmutes all Audios.
        public static void MuteAudio()
        {

            INSTANCE.isMute = !INSTANCE.isMute;

            foreach (Audio a in INSTANCE.audios)
                a.source.mute = INSTANCE.isMute;
        }

        #endregion

        #region Fade the Audio.
        
        // Responsible for fading in the background musics.
        public static void FadeIn(float fadeSpeed = 0.5f, int id = 0)
        {
            INSTANCE.StartCoroutine(INSTANCE.EnumFadeIn(fadeSpeed, id));
        }

        // Logarithmically fades in the Audio.
        private IEnumerator EnumFadeIn(float fadeSpeed, int id)
        {

            Audio a = FindAudio(id);

            a.source.volume = a.volume.minValue;

            a.source.Play();

            while(a.source.volume < a.volume.getStoredValue())
            {

                yield return null;

                //a.source.volume /= fadeSpeed;
                a.source.volume = CalculateFadeIn(a.source.volume, fadeSpeed);
                Debug.Log("Fades In: " + a.source.volume + " volume.");

            }

            a.source.volume = a.volume.getStoredValue();

            Debug.Log("Fades In: " + a.source.volume + " volume.");

        }
        
        // Responsible for fading out the background musics.
        public static void FadeOut(float fadeSpeed = 0.5f, int id = 0)
        {
            INSTANCE.StartCoroutine(INSTANCE.EnumFadeOut(fadeSpeed, id));
        }

        // Logarithmically fades out the Audio.
        private IEnumerator EnumFadeOut(float fadeSpeed, int id)
        {

            Audio a = FindAudio(id);

            while (a.source.volume > a.volume.minValue)
            {

                // Waits for one frame.
                yield return null;

                //a.source.volume *= fadeSpeed;
                a.source.volume = CalculateFadeOut(a.source.volume, fadeSpeed);
                Debug.Log("Fades Out: " + a.source.volume + " volume.");
            }

            a.source.volume = a.volume.minValue;

            Debug.Log("Fades Out: " + a.source.volume + " volume.");

            a.source.Stop();

        }

        ///<summary> Increase volume logarithmically. </summary>
        private float CalculateFadeIn(float currentVolume, float fadeSpeed)
        {
            return currentVolume / fadeSpeed;
        }

        ///<summary> Decrease volume logarithmically. </summary>
        private float CalculateFadeOut(float currentVolume, float fadeSpeed)
        {
            return currentVolume * fadeSpeed;
        }

        #endregion

        #region Find the Audio.
        
        // Finds a particular Audio using its id through binary search optimized for AudioManager.
        private Audio FindAudio(int id)
        {

            int low = 0, high = audios.Length - 1, mid = (low + high) / 2;

            while (low <= high)
            {
                if (audios[mid].id < id)
                    low = mid + 1;

                else if (audios[mid].id > id)
                    high = mid - 1;

                else
                    return audios[mid];

                mid = (low + high) / 2;
            }

            return null;

        }

        public static int FindBGMAudioID()
        {

            //Audio audio = null;
            int audioID = -1;

            // Linear search.
            for(int i = 0; i < INSTANCE.audios.Length; i++)
            {

                // If it is a SFX, skip.
                if (INSTANCE.audios[i].audioType == AudioType.SFX)
                    continue;

                else
                {
                    
                    // If it is playing, store and break the loop.
                    if (IsPlaying(i + 1))
                    {
                        audioID = i + 1;
                        break;
                    }

                }

            }

            print("Current BGM playing: " + audioID);

            return audioID;

        } 

        #endregion

        #region Getter(s)


        // Returns true if the Audio is playing, otherwise false.
        public static bool IsPlaying(int id)
        {

            if (INSTANCE == null)
                return false;

            return INSTANCE.FindAudio(id).source.isPlaying;

        }

        // Returns if the Audio is muted/unmuted, otherwise false.
        public static bool IsMute()
        {
            if (INSTANCE == null)
                return false;

            return INSTANCE.isMute;
        }

        #endregion

        #region Setter(s)

        #endregion

        #region Adjust the Audio.

        // Adjust the volume depending on the audio type.
        public static void AdjustVolume(AudioType audioType, FadeType fadeType, float value)
        {

            if (INSTANCE == null || audioType == AudioType.None || value <= 0 || value >= 1) { return; }

            foreach (Audio a in INSTANCE.audios)
            {
                
                if (a.audioType == audioType)
                {
                    
                    if (fadeType == FadeType.FadeIn)
                    {

                        if (a.source.mute)
                        {
                            a.source.mute = false;
                        }

                        if ((a.source.volume / value) < a.volume.maxValue)
                            a.source.volume /= value;

                        else
                        {
                            a.source.volume = a.volume.maxValue;
                        }

                    }

                    else if (fadeType == FadeType.FadeOut)
                    {

                        if ((a.source.volume * value) > 0.1f)
                            a.source.volume *= value;

                        else
                        {
                            a.source.volume = 0.1f;
                            a.source.mute = true;
                            
                        }

                    }

                    a.volume.setStoredValue(a.source.volume);
                    Debug.Log("Volume: " + a.source.volume);

                }

            }

        }

        #endregion
        
    }

}