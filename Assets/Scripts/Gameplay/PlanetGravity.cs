using UnityEngine;

namespace Gameplay
{
    public class PlanetGravity : MonoBehaviour
    {
        [SerializeField] private Transform planet;
        [SerializeField] private float gravityStrength = 0.5f;

        public void SetGravityStrength(float strength)
        {
            gravityStrength = strength;
        }

        private void FixedUpdate()
        {
            Asteroid[] asteroids = FindObjectsOfType<Asteroid>();

            foreach (var a in asteroids)
            {
                Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
                if (rb == null) continue;

                Vector2 dir = (planet.position - a.transform.position).normalized;

                rb.AddForce(dir * (gravityStrength * Time.fixedDeltaTime), ForceMode2D.Force);
            }
        }
    }
}