using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.InputSystem;
public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cutscenePanel;
    [SerializeField] private Image cutsceneImage;
    [SerializeField] private List<Sprite> cutsceneSprites = new ();
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Animation")]
    [SerializeField] private float delayBeforeCutsceneStart = 1f;
    [SerializeField] private float panelFadeDuration = 0.5f;


    private bool onNext = false;
    private bool isTransitioning = false; // Mencegah input pemain saat animasi Fade berjalan
    private Coroutine cutsceneCoroutine;

    private void Start()
    {
        InitializeComic();
    }

    public void InitializeComic()
    {
        cutscenePanel.SetActive(true);
        canvasGroup.alpha = 0f;

        if (cutsceneCoroutine != null)
        {
            StopCoroutine(cutsceneCoroutine);
        }

        cutsceneCoroutine = StartCoroutine(CutsceneStartRoutine());
    }

    private IEnumerator CutsceneStartRoutine()
    {
        // Delay opsional sebelum cutscene dimulai
        yield return new WaitForSeconds(delayBeforeCutsceneStart);

        foreach (Sprite nextSprite in cutsceneSprites)
        {
            if (nextSprite == null) continue;

            // 1. Pasang sprite baru & kunci input
            cutsceneImage.sprite = nextSprite;
            isTransitioning = true;
            onNext = false;

            // 2. FADE IN
            yield return canvasGroup.DOFade(1f, panelFadeDuration).WaitForCompletion();

            // 3. Buka kuncian input setelah Fade In selesai
            isTransitioning = false;

            // 4. TUNGGU INPUT PEMAIN
            yield return new WaitUntil(() => onNext);
            onNext = false; // Reset flag

            // 5. FADE OUT
            isTransitioning = true;
            yield return canvasGroup.DOFade(0f, panelFadeDuration).WaitForCompletion();
        }

        // Selesai semua cutscene -> tutup panel
        CloseCutscene();
    }

    public void OnNextCutscene(InputAction.CallbackContext ctx)
    {
        // Hanya terima input jika tombol dilepas DAN sedang tidak dalam transisi Fade
        if (ctx.canceled && !isTransitioning)
        {
            onNext = true;
        }
    }

    public void CloseCutscene()
    {
        if (cutsceneCoroutine != null)
        {
            StopCoroutine(cutsceneCoroutine);
            cutsceneCoroutine = null;
        }

        canvasGroup.alpha = 0f;
        cutscenePanel.SetActive(false);
        if(SceneController.instance != null)
            SceneController.instance.GameScene();
    }
}
