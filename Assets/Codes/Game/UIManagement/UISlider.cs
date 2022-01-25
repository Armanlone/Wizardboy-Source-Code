using UnityEngine;
using UnityEngine.UI;
using Game.AudioManagement;

namespace Game.UIManagement
{

    ///<summary> Slider for volume. </summary>
    public class UISlider : MonoBehaviour
    {

        [Tooltip("Attach the Slider reference here.")]
        [SerializeField]
        private Slider _slider = null;

        [Tooltip("Amount of value to be added to slider's value.")]
        [SerializeField]
        private float value = 0.1f;

        // Sets the value of slider attached.
        public void SetValue()
        {

            if (_slider == null)
                return;

            if (_slider.value + value >= _slider.maxValue)
            {
                _slider.value = _slider.maxValue;
            }

            else if (_slider.value + value <= _slider.minValue)
            {
                _slider.value = _slider.minValue;
            }

            else
            {

                _slider.value += value;
                //Debug.Log(_slider.value);
            
            }

        } 

    }


}