using HealthSystem;
using UnityEngine;

namespace Combat
{
    public class RangedProjectile : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float projectileSpeed;
        [SerializeField] private GameObject impactEffect;
        [SerializeField] private int projectileDamage=20;

        private Rigidbody2D rb;
        #endregion

        #region Methods
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * projectileSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                var healthComponent = other.gameObject.GetComponent<Health>();
                
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(projectileDamage/2);
                }
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        #endregion
    }
}
