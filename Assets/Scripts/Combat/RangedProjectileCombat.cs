using UnityEngine;

namespace Combat
{
    public class RangedProjectileCombat : MonoBehaviour
    {
        [SerializeField] private Transform projectilePosition;
        [SerializeField] private GameObject projectile;

        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(projectile, projectilePosition.position, projectilePosition.rotation);
            }
        }
    }
}
