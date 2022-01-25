using UnityEngine;

namespace Game.AudioManagement
{
    
    public class AudioPlayerSoundRandomizer : MonoBehaviour
    {
        
        public int[] IDs;

        public void SoundRandomizer()
        {

            bool isArrayHasZeroAndNegative = false;

            foreach(int ID in IDs)
            {
                isArrayHasZeroAndNegative = ID <= 0;
            }

            if (isArrayHasZeroAndNegative)
                return;

            AudioManager.PlayRandomAudio(IDs);
        
        }

    }

}