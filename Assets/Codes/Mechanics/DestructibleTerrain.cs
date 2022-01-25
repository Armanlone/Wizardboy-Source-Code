using UnityEngine;
using UnityEngine.Events;

namespace Mechanics
{

    ///<summary>
    /// Destroys platform if anything is on top for X amount of time.
    ///</summary>
    public class DestructibleTerrain : MonoBehaviour
    {
        
        [SerializeField]
        private UnityEvent onStandOnTop = new UnityEvent();
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.gameObject.transform.position.y > this.transform.position.y)
            {
                onStandOnTop?.Invoke();
            }

        }

    }

}