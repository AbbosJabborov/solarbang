using System.Collections.Generic;
using Gameplay;
using ScriptableObject;
using UnityEngine;

namespace System
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Planet Order")]
        [SerializeField] private List<PlanetData> planets;

        [Header("References")]
        [SerializeField] private Transform player;
        [SerializeField] private SpriteRenderer planetSpriteRenderer;
        [SerializeField] private PlanetGrowth planetGrowth;
        [SerializeField] private GoalController goalController;
        [SerializeField] AsteroidSpawner spawner;
        [SerializeField] private PlanetGravity gravity;
        

        private int currentIndex = 0;
        private Vector3 baseScale = Vector3.one;

        private void Start()
        {
            baseScale = player.localScale;
            LoadPlanet(0);
        }

        public void LoadNextPlanet()
        {
            currentIndex++;

            if (currentIndex >= planets.Count)
            {
                Debug.Log("ALL PLANETS COMPLETED!");
                return;
            }

            LoadPlanet(currentIndex);
        }

        private void LoadPlanet(int index)
        {
            PlanetData data = planets[index];

            // Reset size
            player.localScale = baseScale;

            // Change sprite
            planetSpriteRenderer.sprite = data.planetSprite;

            // Update growth target
            goalController.SetRequiredSize(data.targetSize);
            goalController.ResetGoal();

            // Update gravity
            gravity.SetGravityStrength(data.gravityStrength);

            // Update spawn profile
            spawner.SetSpawnProfile(data.spawnProfile);

            ClearAsteroids();

            Debug.Log("Loaded planet: " + data.planetName);
        }

        

        private void ClearAsteroids()
        {
            Asteroid[] asteroids = FindObjectsOfType<Asteroid>();
            foreach (var a in asteroids) Destroy(a.gameObject);
        }
    }
}