using UnityEngine;

namespace Game.UIManagement
{
    
    public class UIFader : MonoBehaviour
    {
        
        [SerializeField]
        private CanvasGroup _canvasGroup = null;

        [Tooltip("The end value of the alpha.")]
        [SerializeField]
        [Range(0f, 1f)]
        private float alphaEndValue = 1f;

        [Tooltip("The duration of the fade.")]
        [SerializeField]
        [Range(0f, 1f)]
        private float duration = 1f;

        ///<summary> Fades the canvasgroup. </summary>
        public void Fade()
        {

            if (_canvasGroup == null)
                return;

            UIManager.Fade(_canvasGroup, alphaEndValue, duration);
        
        }

    }

}