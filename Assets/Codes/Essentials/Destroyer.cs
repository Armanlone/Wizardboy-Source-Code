using UnityEngine;

namespace Essentials
{
        
    ///<summary>
    /// Destroyer of a gameObject.
    ///</summary>
    public class Destroyer : MonoBehaviour
    {
        
        [Tooltip("Destroy the gameObject attached.")]
        [SerializeField]
        private GameObject _gameObject = null;
        
        ///<summary> Destroy gameObject. </summary>
        public void Destroy()
        {
            
            if (_gameObject == null)
                Destroy(this.gameObject);

            else
            {
                Destroy(_gameObject);  
            }

        }

    }

}
