using UnityEngine;
using UnityEngine.Events;
using Game.LevelManagement;

namespace Essentials
{
    
    ///<summary> A trap that makes the player get game over. </summary>

    public class TriggerTrap : MonoBehaviour
    {

        [SerializeField]
        private string tagnamePlayer = "Player";

        [SerializeField]
        private UnityEvent onTrigger = new UnityEvent();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.CompareTag(tagnamePlayer))
            {
                onTrigger?.Invoke();
            }

        }

    }

}