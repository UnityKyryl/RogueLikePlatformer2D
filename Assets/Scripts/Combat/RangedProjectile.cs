using UnityEngine;

namespace Combat
{
    public class RangedProjectile : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float projectileSpeed;
        [SerializeField] private GameObject impactEffect;

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
                Destroy(other.gameObject);
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        #endregion
    }
}
