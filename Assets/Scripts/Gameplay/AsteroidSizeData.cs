using UnityEngine;

namespace Gameplay
{
    [System.Serializable]
    public class AsteroidSizeData
    {
        public string name;

        [Header("Scale Range")]
        public float minScale = 0.5f;
        public float maxScale = 1.8f;

        [Header("Spawn Probability Weight")]
        [Range(0f, 1f)] public float weight = 1f;

        [Header("Mass")]
        public float massMultiplier = 1f;
    }
}