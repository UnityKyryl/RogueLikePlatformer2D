using UnityEngine;
using System;
namespace HealthSystem
{
    public class Health : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;

        private Animator anim;
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int Hurt = Animator.StringToHash("Hurt");


        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            anim.SetTrigger(currentHealth <= 0 ? Dead : Hurt);
        }

    }
}
