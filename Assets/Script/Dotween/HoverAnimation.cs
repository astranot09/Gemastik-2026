using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class HoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Hover Settings")]
    [SerializeField] private Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);
    [SerializeField] private float animationDuration = 0.2f;
    [SerializeField] private Ease animationEase = Ease.OutQuad;

    private Vector3 originalScale;
    private Tween activeTween;

    private void Awake()
    {
        // Simpan ukuran asli objek saat game mulai
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Kill tween yang sedang berjalan agar animasi tidak tabrakan/bug saat mouse di-hover dengan cepat
        activeTween?.Kill();

        // Animasi membesar ke hoverScale
        activeTween = transform.DOScale(originalScale.x * hoverScale.x, animationDuration)
            .SetEase(animationEase)
            .SetUpdate(true); // SetUpdate(true) agar animasi tetap jalan walau Time.timeScale = 0 (Game Paused)
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        activeTween?.Kill();

        // Kembalikan ukuran ke skala awal
        activeTween = transform.DOScale(originalScale, animationDuration)
            .SetEase(animationEase)
            .SetUpdate(true);
    }

    private void OnDisable()
    {
        // Bersihkan tween jika objek di-disable / ditutup di pertengahan animasi
        activeTween?.Kill();
        transform.localScale = originalScale;
    }
}