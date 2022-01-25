using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Game.DebugManagement;
using Game.SpriteAnimation;

namespace Game.UIManagement
{

    ///<summary>
    /// Managing UIs interacts to user inputs.
    ///</summary>

    public class UIManager : MonoBehaviour
    {
        
        private static UIManager INSTANCE = null;

        [SerializeField]
        private GameObject objMainMenu = null;

        [SerializeField]
        private GameObject objSettings = null;

        [SerializeField]
        private GameObject objTransition = null;

        [SerializeField]
        private GameObject objFlash = null;

        [SerializeField]
        private GameObject objTitleScreen = null;

        
        [SerializeField]
        private GameObject objRewindGlitch = null;

        [SerializeField]
        private Animations animationsRewindGlitch = null;

        private void Awake()
        {
            
            if (INSTANCE != null && INSTANCE != this)
            {

                Destroy(gameObject);
                return;

            }

            INSTANCE = this;

            //try
            DOTween.Init(true, true, LogBehaviour.ErrorsOnly);

            DontDestroyOnLoad(gameObject);

            DebugManager.ShowDebug("UI Manager created.");

        }

        // Fades in/out the canvas group.
        public static void Fade(CanvasGroup canvasGroup, float endValue, float duration)
        {

            if (INSTANCE == null || canvasGroup == null)
                return;

            else
            {
                canvasGroup.DOFade(endValue, duration).Kill(true);

            }

        }

        #region Getter(s)

        public static GameObject getTitleScreen()
        {
            
            if (INSTANCE == null)
                return null;

            return INSTANCE.objTitleScreen;

        }

        public static GameObject getMainMenu()
        {
            
            if (INSTANCE == null)
                return null;

            return INSTANCE.objMainMenu;

        }

        public static Animations getRewindGlitchAnimations()
        {
            
            if (INSTANCE == null)
                return null;

            return INSTANCE.animationsRewindGlitch;

        }

        public static GameObject getSettings()
        {
            
            if (INSTANCE == null)
                return null;

            return INSTANCE.objSettings;

        }

        public static GameObject getFlash()
        {
            
            if (INSTANCE == null)
                return null;

            return INSTANCE.objFlash;

        }

        public static GameObject getTransition()
        {
            
            if (INSTANCE == null)
                return null;

            return INSTANCE.objTransition;

        }

        
        public static GameObject getRewindGlitch()
        {
            
            if (INSTANCE == null)
                return null;

            return INSTANCE.objRewindGlitch;

        }

        public static CanvasGroup getCanvasGroupTransition()
        {
            if (INSTANCE == null)
                return null;

            return (INSTANCE.objTransition == null) ? null : INSTANCE.objTransition.GetComponent<CanvasGroup>();
        }

        #endregion

    }

}