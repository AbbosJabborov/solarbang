using UnityEngine;

namespace Gameplay
{
    public class PlanetGrowth : MonoBehaviour
    {
        [SerializeField] private float growthPerUnit = 0.05f; 
        private float _currentMass;

        public void AddMass(float amount)
        {
            _currentMass += amount;
            float scaleIncrease = amount * growthPerUnit;

            Vector3 newScale = transform.localScale;
            newScale += Vector3.one * scaleIncrease;
            transform.localScale = newScale;
        }
        public void RemoveMass(float amount)
        {
            _currentMass = Mathf.Max(0f, _currentMass - amount);

            Vector3 newScale = transform.localScale;
            newScale -= Vector3.one * (amount * growthPerUnit);
            newScale.x = Mathf.Max(newScale.x, 0.3f);
            newScale.y = Mathf.Max(newScale.y, 0.3f);
            transform.localScale = newScale;
        }

    }
}