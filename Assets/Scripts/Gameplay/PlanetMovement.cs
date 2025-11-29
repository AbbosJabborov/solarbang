using UnityEngine;

namespace Gameplay
{
    public class PlanetMovement : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 120f;
        private float _rotationInput;

        private void Update()
        {
            // Read input (left/right)
            _rotationInput = Input.GetAxisRaw("Horizontal");
        
            // Rotate planet
            transform.Rotate(Vector3.forward * (-_rotationInput * rotationSpeed * Time.deltaTime));
        }
    }
}