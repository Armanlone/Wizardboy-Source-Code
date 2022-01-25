using UnityEngine;

namespace Essentials
{
        
    ///<summary>
    /// Spawns a gameObject.
    ///</summary>
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameObject = null;

        public void Spawn()
        {
            
            if (_gameObject == null)
                return;

            else
            {
                Instantiate(_gameObject, transform.position, Quaternion.identity);
            }

        }

    }

}