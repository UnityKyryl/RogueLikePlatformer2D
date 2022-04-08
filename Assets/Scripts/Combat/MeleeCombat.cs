using System;
using UnityEngine;

namespace Combat
{
    public class MeleeCombat : MonoBehaviour
    {
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private LayerMask enemyLayers;
        [SerializeField] private GameObject impactEffect;
        
        private Animator anim;
    
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }

        void Attack()
        {
            anim.SetTrigger(AttackTrigger);
            var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (var enemy in hitEnemies)
            {
                Instantiate(impactEffect, enemy.transform.position, Quaternion.identity);
                Destroy(enemy.gameObject);
            }
        }

        //Uncomment to check attack range
        
        // private void OnDrawGizmosSelected()
        // {
        //     if(attackPoint==null)
        //         return;
        //     Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        // }
    }
}
