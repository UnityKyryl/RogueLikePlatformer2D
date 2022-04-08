using UnityEngine;

namespace Combat
{
    public class RangedProjectileCombat : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Transform projectilePosition;
        [SerializeField] private GameObject projectile;
        #endregion

        #region Methods

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(projectile, projectilePosition.position, projectilePosition.rotation);
            }
        }

        #endregion

    }
}
