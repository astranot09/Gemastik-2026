using UnityEngine;
using DG.Tweening;
using TMPro;

public class NotificationAnimation : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private RectTransform notificationUI;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TMP_Text notificationText;


    [Header("Animation Settings")]
    [SerializeField] private float moveDistance = 50f; // Jarak melayang ke atas (in pixels)
    [SerializeField] private float fadeInDuration = 0.3f;
    [SerializeField] private float displayDuration = 1.5f; // Durasi diam saat terlihat
    [SerializeField] private float fadeOutDuration = 0.4f;

    private Vector2 startPosition;
    private Sequence notificationSequence;

    private void Awake()
    {
        // Simpan posisi awal UI di Canvas
        if (notificationUI != null)
        {
            startPosition = notificationUI.anchoredPosition;
        }
    }

    public void ShowNotification(string notif)
    {
        // Matiin sequence sebelumnya kalau notifikasi dipanggil lagi pas animasi masih jalan
        notificationSequence?.Kill();

        // 1. RESET STATE AWAL
        canvasGroup.alpha = 0f;
        notificationUI.anchoredPosition = startPosition;
        notificationUI.gameObject.SetActive(true);

        // 2. BIKIN SEQUENCE DOTWEEN
        notificationSequence = DOTween.Sequence();


        notificationText.text = notif;


        // --- STEP A: FADE IN & NAIK ---
        // Join dipake supaya DOFade dan DOAnchorPosY jalan BERSAMAAN
        notificationSequence.Append(canvasGroup.DOFade(1f, fadeInDuration));
        notificationSequence.Join(notificationUI.DOAnchorPosY(startPosition.y + moveDistance, fadeInDuration).SetEase(Ease.OutQuad));

        // --- STEP B: TAHAN / DELAY ---
        notificationSequence.AppendInterval(displayDuration);

        // --- STEP C: FADE OUT & NAIK DIKIT LAGI ---
        notificationSequence.Append(canvasGroup.DOFade(0f, fadeOutDuration));
        notificationSequence.Join(notificationUI.DOAnchorPosY(startPosition.y + (moveDistance * 1.5f), fadeOutDuration).SetEase(Ease.InQuad));

        // --- STEP D: ON COMPLETE ---
        notificationSequence.OnComplete(() =>
        {
            notificationUI.gameObject.SetActive(false);
            notificationUI.anchoredPosition = startPosition; // Reset posisi
            Destroy(gameObject);
        });
    }

    private void OnDestroy()
    {
        // Selalu kill tween pas object dihancurkan biar gak memory leak
        notificationSequence?.Kill();
    }
}
