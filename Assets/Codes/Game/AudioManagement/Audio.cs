using UnityEngine;

namespace Game.AudioManagement
{
    
    [System.Serializable]
    public class Audio
    {

        public string name = "";

        [HideInInspector]
        public int id = 0;

        [Space]
        [Header("Components:")]

        public AudioClip clip = null;

        [Space]

        public AudioValues volume = new AudioValues();
        
        public AudioValues pitch = new AudioValues();

        [Space]
        public bool isLoop = false;

        [Space]
        public AudioType audioType = AudioType.BGM;

        [HideInInspector]
        public AudioSource source = null;

    }

}