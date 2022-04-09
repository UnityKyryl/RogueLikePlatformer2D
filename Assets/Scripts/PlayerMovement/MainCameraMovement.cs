using UnityEngine;

namespace PlayerMovement
{
    public class MainCameraMovement : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform playerTransform;
    
        private Camera mainCamera;
        #endregion

        #region Methods
        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            var transform1 = mainCamera.transform;
            var position = transform1.position;
            position =
                new Vector3(playerTransform.position.x, position.y,
                    position.z);
            transform1.position = position;
        }
        #endregion
    }
}
