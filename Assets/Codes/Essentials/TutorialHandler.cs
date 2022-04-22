using UnityEngine;
using Game.ControlsManagement;

namespace Essentials
{
    
    public class TutorialHandler : MonoBehaviour
    {
        
        public Key key;

        public Behaviour[] behaviours;

        private void Update()
        {

            foreach(Behaviour behaviour in behaviours)
            {
                behaviour.enabled = ControlsManager.GetKey(key.keyName) == key.keyCode;
            }

        }


    }

}