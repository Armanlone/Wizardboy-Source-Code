using UnityEngine.UI;
using UnityEngine;
using Game;

namespace Mechanics
{
    
    ///<summary>
    /// Enables Key image instantly when player gets the key.
    ///</summary>

    public class KeyUIActivator : MonoBehaviour
    {
        
        [SerializeField]
        private Image _image = null;

        [SerializeField]
        private Color _color = Color.white;

        private void Update()
        {
            
            if (_image == null)
                return;

            else if (GameManager.getIsLevelClear())
            {
                _image.color = _color;
            }

        }

    }

}