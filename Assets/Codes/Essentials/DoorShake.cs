using UnityEngine;
using Game.SpriteAnimation;
using Game;

namespace Essentials
{

    ///<summary>
    /// Shakes the door through animation if player gets the key.
    ///</summary>

    public class DoorShake : MonoBehaviour
    {

        [SerializeField]
        private Animations animations = null;

        private bool storedIsShake = false;

        private void Update()
        {

            if (animations == null)
                return;

            else
            {

                // Avoid setting up again.
                if (storedIsShake != GameManager.getIsLevelClear())
                {
                    animations.Animate("isShake", GameManager.getIsLevelClear());
                    storedIsShake = GameManager.getIsLevelClear();
                }

            }
            
        }

    }


}