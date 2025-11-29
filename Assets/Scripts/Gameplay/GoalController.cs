using System;
using UnityEngine;

namespace Gameplay
{
    public class GoalController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private float requiredSize = 1.5f;
        [SerializeField] private float checkInterval = 0.2f;

        private float _timer;
        private bool _completed;

        private void Update()
        {
            if (_completed) return;

            _timer += Time.deltaTime;
            if (_timer >= checkInterval)
            {
                _timer = 0f;
                CheckGoal();
            }
        }

        private void CheckGoal()
        {
            if (player.localScale.x >= requiredSize)
            {
                _completed = true;
                levelManager.LoadNextPlanet();
            }
        }
        public void ResetGoal()
        {
            _completed = false;
            _timer = 0f;
        }


        /// <summary>
        /// Called by LevelManager when a new planet loads.
        /// Sets the required size and scales the goal outline.
        /// </summary>
        public void SetRequiredSize(float size)
        {
            requiredSize = size;

            float outlineScale = size + 0.1f;
            transform.localScale = new Vector3(outlineScale, outlineScale, 1f);
        }
    }
}