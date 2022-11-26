using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PureMVPTestbed.Health
{
    public class HealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI healthLabel;

        private void Start()
        {
            healthLabel.text = healthSlider.value.ToString(CultureInfo.CurrentCulture);
        }

        public void SetSliderMinMaxValue(int min, int max)
        {
            healthSlider.minValue = min;
            healthSlider.maxValue = max;
            healthSlider.value = max;
        }

        public void SetHealthValue(int health)
        {
            healthSlider.value = health;
            healthLabel.text = healthSlider.value.ToString(CultureInfo.CurrentCulture);
        }
    }
}