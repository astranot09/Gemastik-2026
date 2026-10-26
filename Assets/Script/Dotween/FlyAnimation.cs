using DG.Tweening;
using UnityEngine;

public class FlyAnimation : MonoBehaviour
{
    [Header("Fly Settings")]
    [SerializeField] private Transform targetFly;
    [SerializeField] private float flyDuration = 0.75f;

    [Header("Idle Settings")]
    [SerializeField] private float posYIdle = 0.5f;
    [SerializeField] private float idleDuration = 4f;

    [Header("Idle Rotation Settings")]
    [SerializeField] private Vector3 idleRotationAmount = new Vector3(0f, 0f, 5f); // Kemiringan rotasi (misal: 5 derajat di Z)
    [SerializeField] private float rotateDuration = 1.5f;


    private Sequence flySequence;
    private Sequence idleSequence;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        AnimationFly();
    }
    public void AnimationFly()
    {
        KillTweens();

        flySequence = DOTween.Sequence();

        flySequence.Append(transform.DOMove(targetFly.position, flyDuration).SetEase(Ease.OutBack))
            .SetUpdate(true)
            .OnComplete(IdleFly);
    }

    private void IdleFly()
    {
        float targetY = transform.position.y;
        Vector3 baseEuler = initialRotation.eulerAngles;

        idleSequence = DOTween.Sequence();

        // Gunakan Ease.InOutSine untuk gerakan mengapung/melayang yang murni organik
        idleSequence.Append(
            transform.DOMoveY(targetY + posYIdle, idleDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo)
        ).SetUpdate(true);

        idleSequence.Join(
            transform.DORotate(baseEuler + idleRotationAmount, rotateDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo)
        ).SetUpdate(true);
    }

    private void KillTweens()
    {
        flySequence?.Kill();
        idleSequence?.Kill();
    }

    private void OnDestroy()
    {
        KillTweens();
    }
}
