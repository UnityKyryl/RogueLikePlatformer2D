using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    public class PlayerHealthBar : MonoBehaviour
    {
        public Health playerHealth;
        public Image fillImage;

        private Slider slider;
        private float fillValue;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }
        
        private void Update()
        {
            if (slider.value <= slider.minValue)
            {
                fillImage.enabled = false;
            }
            if (slider.value > slider.minValue && !fillImage.enabled)
            {
                fillImage.enabled = true;
            }
            fillValue = (float)playerHealth.currentHealth / playerHealth.maxHealth;
            slider.value = fillValue;
        }
    }
}
