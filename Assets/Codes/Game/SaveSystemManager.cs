using UnityEngine;

namespace Game.SaveSystemManagement
{
    ///<summary>
    /// Saves the system's data in PlayerPrefs. 
    ///</summary>

    public class SaveSystemManager : MonoBehaviour
    {
        
        #region Singleton
        private static SaveSystemManager INSTANCE = null;

        private void Awake()
        {

            if (INSTANCE != null && INSTANCE != this)
            {

                Destroy(gameObject);
                return;

            }

            INSTANCE = this;

            DontDestroyOnLoad(gameObject);

            Debug.Log("Save System Manager created.");

        }
        
        #endregion

        #region Setter(s).

        // Saves the data in FLOAT.
        public static void setSaveData(string keyName, float value)
        {

            if (INSTANCE == null)
                return;

            PlayerPrefs.SetFloat(keyName, value);

        }

        // Saves the data in INT.
        public static void setSaveData(string keyName, int value)
        {

            if (INSTANCE == null)
                return;

            PlayerPrefs.SetInt(keyName, value);

        }

        // Saves the data in STRING.
        public static void setSaveData(string keyName, string value)
        {

            if (INSTANCE == null)
                return;

            if (string.IsNullOrEmpty(keyName) || string.IsNullOrWhiteSpace(keyName))
            {
                print("There's no STRING value attached. Please input a STRING value first before saving.");
                return;
            }

            PlayerPrefs.SetString(keyName, value);
        
        }

        #endregion

        #region Getter(s)

        // Gets the data in FLOAT.
        public static float getFloatData(string keyName)
        {
            return (string.IsNullOrEmpty(keyName) || string.IsNullOrWhiteSpace(keyName)) ? -0f : PlayerPrefs.GetFloat(keyName);
        }

        // Gets the data in INT.
        public static int getIntData(string keyName)
        {
            return (string.IsNullOrEmpty(keyName) || string.IsNullOrWhiteSpace(keyName)) ? -1 : PlayerPrefs.GetInt(keyName);
        }

        // Gets the data in STRING.
        public static string getStringData(string keyName)
        {
            return (string.IsNullOrEmpty(keyName) || string.IsNullOrWhiteSpace(keyName)) ? null : PlayerPrefs.GetString(keyName);
        }

        #endregion

    }

}