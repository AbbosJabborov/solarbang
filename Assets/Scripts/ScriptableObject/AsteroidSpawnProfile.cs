using Gameplay;
using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(menuName = "Data/Asteroid Spawn Profile")]
    public class AsteroidSpawnProfile : UnityEngine.ScriptableObject
    {
        [Header("Normal Asteroids")]
        public GameObject[] normalAsteroids;

        [Header("Red Asteroids")]
        public GameObject[] redAsteroids;

        [Header("Type Probability")]
        [Range(0f, 1f)] public float redChance = 0.2f;

        [Header("Size Settings")]
        public AsteroidSizeData[] sizeData;

        public GameObject RollAsteroidPrefab()
        {
            float r = Random.value;

            // Roll for red asteroid
            if (r < redChance && redAsteroids.Length > 0)
                return redAsteroids[Random.Range(0, redAsteroids.Length)];

            // Roll for normal asteroid
            if (normalAsteroids.Length > 0)
                return normalAsteroids[Random.Range(0, normalAsteroids.Length)];

            return null;
        }

        public AsteroidSizeData RollSize()
        {
            float total = 0f;
            foreach (var s in sizeData)
                total += s.weight;

            float r = Random.value * total;

            foreach (var s in sizeData)
            {
                if (r < s.weight) return s;
                r -= s.weight;
            }

            return sizeData[0]; // fallback
        }
    }
}