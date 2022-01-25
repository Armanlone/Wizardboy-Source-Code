using UnityEngine;

namespace Essentials
{
        
    ///<summary>
    /// Destroyer of a component attached then destroys itself.
    ///</summary>

    public class ComponentDestroyer : MonoBehaviour
    {
        
        public Component component = null;

        // Destroys component then destroys this.
        public void DestroyComponent()
        {

            if (component == null)
                return;

            else
            {

                Destroy(component);
                Destroy(this);

            }

        }

    }

}