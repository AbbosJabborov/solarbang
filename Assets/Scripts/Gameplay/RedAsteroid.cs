using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class RedAsteroid : MonoBehaviour
    {
        [SerializeField] private float shrinkAmount = 0.15f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var growth = other.GetComponentInParent<PlanetGrowth>();
            if (growth == null) return;

            growth.RemoveMass(shrinkAmount);

            DestroySelf();
        }

        private void DestroySelf()
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                DOTween.Kill(sr);
                sr.DOFade(0f, 0.3f)
                    .OnComplete(() => Destroy(gameObject));
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}