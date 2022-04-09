using UnityEngine;

namespace HealthSystem
{
    public class EnemyCollideDamage : MonoBehaviour
    {
        [SerializeField] private int healthReductionAmount;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var healthComponent = col.GetComponent<Health>();
                
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(healthReductionAmount);
                }
            }
        }
    }
}
