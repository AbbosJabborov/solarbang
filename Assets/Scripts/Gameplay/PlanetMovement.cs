using UnityEngine;

namespace Gameplay
{
    public class PlanetMovement : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 120f;

        private float _mobileInput;        // From UI buttons
        private float _keyboardInput;      // From A/D or arrows

        private void Update()
        {
            
            _keyboardInput = Input.GetAxisRaw("Horizontal");
            
            
            float finalInput = _mobileInput != 0 ? _mobileInput : _keyboardInput;

            // Rotate
            if (finalInput != 0f)
            {
                transform.Rotate(Vector3.forward * (-finalInput * rotationSpeed * Time.deltaTime));
            }
        }

        // MOBILE — called on PointerDown
        public void HoldLeft()
        {
            _mobileInput = -1f;
        }

        public void HoldRight()
        {
            _mobileInput = 1f;
        }

        // MOBILE — called on PointerUp
        public void StopHold()
        {
            _mobileInput = 0f;
        }
    }
}