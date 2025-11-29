using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class Asteroid : MonoBehaviour
    {
        [Header("Asteroid Properties")]
        public float massValue = 1f;

        [SerializeField] private float lifetime = 10f;
        [SerializeField] private float fadeDuration = 0.5f;

        private SpriteRenderer _sr;
        private bool _isBeingDestroyed = false;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            Invoke(nameof(BeginFadeOut), lifetime);
        }

        public void Eaten()
        {
            if (_isBeingDestroyed) return;

            // Stop auto-destruction timer
            CancelInvoke();

            // Trigger fade
            BeginFadeOut();
        }

        private void BeginFadeOut()
        {
            if (_isBeingDestroyed) return;
            _isBeingDestroyed = true;

            if (_sr == null)
            {
                Destroy(gameObject);
                return;
            }

            DOTween.Kill(_sr);

            _sr.DOFade(0f, fadeDuration)
                .OnKill(() => { if (this != null) Destroy(gameObject); })
                .OnComplete(() => { if (this != null) Destroy(gameObject); });
        }

        public void SetLifetimeMultiplier(float size)
        {
            lifetime = lifetime * Mathf.Lerp(0.8f, 1.4f, size - 0.6f);
        }
    }
}