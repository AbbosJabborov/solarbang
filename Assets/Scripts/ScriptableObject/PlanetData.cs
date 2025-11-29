using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(menuName = "Data/Planet")]
    public class PlanetData : UnityEngine.ScriptableObject
    {
        public string planetName;
        public Sprite planetSprite;

        [Header("Progression")]
        public float targetSize = 2f;

        [Header("Gravity")]
        public float gravityStrength = 0.5f;

        [Header("Asteroid Spawn Profile")]
        public AsteroidSpawnProfile spawnProfile;
    }
}