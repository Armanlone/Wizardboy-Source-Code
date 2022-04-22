using UnityEngine;
using UnityEngine.Events;

namespace Game.SelectionMenu
{
    
    ///<summary>
    /// Item you can select through Selection script.
    /// NOTE: This script is reconfigured to support the button clicking.
    ///</summary>

    public class SelectableItem : MonoBehaviour
    {

        [Tooltip("The Selection script it belongs to.")]
        [SerializeField]
        protected Selection selection = null;

        [Tooltip("Its index in the selection.")]
        [SerializeField]
        protected byte selectionIndex = 1;

        [Space]

        // Things to do if clicked.
        [SerializeField]
        protected UnityEvent onClick = new UnityEvent();

        // @Overriding.
        public virtual void OnEnable()
        {

        }

        public void Click()
        {

            // CLICK STATE
            if (selectionIndex == selection.pointer)
                onClick?.Invoke();

        }

    }

}