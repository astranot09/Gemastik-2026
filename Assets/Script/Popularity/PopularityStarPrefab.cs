using UnityEngine;
using DG.Tweening;

public class PopularityStarPrefab : MonoBehaviour
{
    [SerializeField] private Transform starTransform;
    [SerializeField] private CanvasGroup starCanvas;

    [Header("Scale Settings")]
    [SerializeField] private float scaleUp = 1.2f;
    [SerializeField] private float scaleUpDuration = 0.75f;

    [Header("Fly Settings")]
    [SerializeField] private Transform targetFly;
    [SerializeField] private float flyDuration = 1.25f;

    private Vector2 targetScale;
    private Sequence starSequence;

    private void Start()
    {
        SetUp();
    }
    public void SetUp()
    {
        targetScale = starTransform.localScale * scaleUp;
        targetFly = GameObject.FindGameObjectWithTag("StarLocation").transform;
        AnimationStar();
    }

    public void AnimationStar()
    {
        starSequence = DOTween.Sequence();

        starSequence
            .Append(starTransform.DOScale(targetScale, scaleUpDuration).SetEase(Ease.OutBack))
            .Append(starTransform.DOMove(targetFly.position, flyDuration).SetEase(Ease.InQuad))
            .Join(starCanvas.DOFade(0f, flyDuration/2).SetDelay(flyDuration / 2))
            .SetUpdate(true)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }

    private void OnDestroy()
    {
        starSequence?.Kill();
    }
}
