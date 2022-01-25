
namespace Game.AudioManagement
{

    [System.Serializable]
    public class AudioValues
    {
        
        public float value = 0.1f;
        
        private float storedValue = 0.1f;
        
        public float minValue = 0.1f;
        public float maxValue = 0.1f;

        public void setStoredValue(float value)
        {
            this.storedValue = value;
        }

        public float getStoredValue()
        {
            return this.storedValue;
        }

    }

}