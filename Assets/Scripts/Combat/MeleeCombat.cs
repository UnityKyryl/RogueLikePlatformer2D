using System;
using System.Collections;
using UnityEngine;

namespace Combat
{
    public class MeleeCombat : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private LayerMask enemyLayers;
        [SerializeField] private GameObject impactEffect;
        [SerializeField] private float attackAimationDelay = 0.2f;
        
        private Animator anim;
    
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");
        #endregion

        #region Methods
        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Attack());
            }
        }

        private IEnumerator  Attack()
        {
            anim.SetTrigger(AttackTrigger);
            var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            yield return new WaitForSeconds(attackAimationDelay);
            foreach (var enemy in hitEnemies)
            {
                Instantiate(impactEffect, enemy.transform.position, Quaternion.identity);
                Destroy(enemy.gameObject);
            }
        }

        //Uncomment to check attack range
        
        private void OnDrawGizmosSelected()
        {
            if(attackPoint==null)
                return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
        

        #endregion
       
    }
}
