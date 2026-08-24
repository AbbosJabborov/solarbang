using UnityEngine;

namespace Gameplay
{
    public class PlanetEatController : MonoBehaviour
    {
        [SerializeField] private PlanetGrowth planetGrowth;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Asteroid asteroid = other.GetComponent<Asteroid>();
            if (asteroid == null) return;

            // Tell asteroid it was eaten
            asteroid.Eaten();

            // Increase player size
            planetGrowth.AddMass(asteroid.massValue);
        }
    }
}