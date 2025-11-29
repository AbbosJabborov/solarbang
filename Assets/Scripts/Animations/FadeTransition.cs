using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class FadeTransition : MonoBehaviour
    {
        [SerializeField] private CanvasGroup panel;
        [SerializeField] private float fadeDuration = 0.5f;

        private void Awake()
        {
            panel.alpha = 0f;
            gameObject.SetActive(false);
        }

        public void FadeIn(System.Action onComplete)
        {
            gameObject.SetActive(true);
            panel.alpha = 0f;

            panel.DOFade(1f, fadeDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => onComplete?.Invoke());
        }

        public void FadeOut()
        {
            panel.DOFade(0f, fadeDuration)
                .SetEase(Ease.InQuad)
                .OnComplete(() =>
                            {
                                gameObject.SetActive(false);
                            });
        }
    }
}