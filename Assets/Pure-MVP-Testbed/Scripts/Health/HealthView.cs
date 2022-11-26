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
        
        public void SetHealthValue(int health)
        {
            healthSlider.value = health;
        }
    }
}