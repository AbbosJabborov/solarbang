using ScriptableObject;
using UnityEngine;

namespace Gameplay
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform player;
        [SerializeField] private AsteroidSpawnProfile spawnProfile;

        [Header("Spawn Settings")]
        [SerializeField] private float spawnRadius = 12f;
        [SerializeField] private float spawnInterval = 1.2f;
        [SerializeField] private float minSpeed = 1.5f;
        [SerializeField] private float maxSpeed = 3.5f;

        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                timer = 0f;
                SpawnAsteroid();
            }
        }

        private void SpawnAsteroid()
        {
            GameObject prefab = spawnProfile.RollAsteroidPrefab();
            if (prefab == null) return;

            Vector2 spawnDir = Random.insideUnitCircle.normalized;
            Vector2 spawnPos = (Vector2)player.position + spawnDir * spawnRadius;

            GameObject asteroid = Instantiate(prefab, spawnPos, Quaternion.identity);

            // Handle size
            ApplySize(asteroid);

            // Handle velocity
            ApplyVelocity(asteroid, spawnPos);
        }
        
        public void SetSpawnProfile(AsteroidSpawnProfile profile)
        {
            spawnProfile = profile;
        }

        private void ApplySize(GameObject asteroid)
        {
            AsteroidSizeData size = spawnProfile.RollSize();

            float scale = Random.Range(size.minScale, size.maxScale);
            asteroid.transform.localScale = Vector3.one * scale;

            var ast = asteroid.GetComponent<Asteroid>();
            if (ast != null)
                ast.massValue *= (scale * size.massMultiplier);

            var col = asteroid.GetComponent<CircleCollider2D>();
            if (col != null)
                col.radius *= scale;
        }

        private void ApplyVelocity(GameObject asteroid, Vector2 spawnPos)
        {
            Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
            if (rb == null) return;

            float aimRandomRadius = 2f;
            Vector2 targetOffset = Random.insideUnitCircle * aimRandomRadius;
            Vector2 targetPos = (Vector2)player.position + targetOffset;

            Vector2 finalDir = (targetPos - spawnPos).normalized;
            finalDir += (Vector2)Random.insideUnitCircle * 0.05f;
            finalDir.Normalize();

            float baseSpeed = Random.Range(minSpeed, maxSpeed);
            rb.linearVelocity = finalDir * baseSpeed;
        }

        public void SetRedChance(float chance)
        {
            spawnProfile.redChance = chance;
        }
    }
}
