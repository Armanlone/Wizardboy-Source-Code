using UnityEngine;
using Game.DebugManagement;

namespace Game.CameraManagement
{

    ///<summary>
    /// Managing the camera's behaviour.
    ///</summary>

    public class CameraManager : MonoBehaviour
    {

        private static CameraManager INSTANCE = null;

        private void Awake()
        {
            
            if (INSTANCE != null && INSTANCE != this)
            {

                Destroy(gameObject);
                return;

            }

            INSTANCE = this;

            DontDestroyOnLoad(gameObject);

            DebugManager.ShowDebug("Camera Manager created.");

        }

        [Tooltip("Attach the Transform component of the Main Camera here.")]
        [SerializeField]
        private Transform cameraTransform = null;

        // Stores the original Transform of the Camera.
        private Vector3 storedCameraPosition = Vector3.zero;

        // Power of the shake.
        private float power = 0f;

        // How long is the shake.
        private float duration = 0f;

        // Should the camera shake?
        private bool shouldShake = false;

        // Store camera's transform at start.
        private void Start()
        {
            storedCameraPosition = cameraTransform.position;
        }

        // Camera goes brrr.
        public static void CameraShake(float power, float duration)
        {

            if (INSTANCE == null)
                return;

            INSTANCE.power = power;
            INSTANCE.duration = duration;
            INSTANCE.shouldShake = true;

        }

        // Method overload. Shakes the camera.
        private void CameraShake()
        {

            if (!shouldShake)
                return;

            else
            {
                
                if (duration <= 0f)
                {

                    // Reset
                    cameraTransform.position = storedCameraPosition;
                    duration = power = 0f;
                    shouldShake = false;

                }

                else
                {

                    // Enhanced random vector.
                    Vector3 poweredRandomVector = Random.insideUnitCircle * power;

                    // Set the calculated random vector to the transform of camera.
                    cameraTransform.localPosition = storedCameraPosition + poweredRandomVector;
                    
                    // Countdown--
                    duration -= Time.deltaTime;

                }

            }

        }

    }

}


/* OLD SCRIPT:


private void Update()
{
    CameraShake();
}

*/