using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class DialogueUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private DialogueSO dialogueData;

    [Header("UI -- Speaker 1")]
    [SerializeField] private TMP_Text speakerName1;
    [SerializeField] private Image speakerImage1;

    [Header("UI -- Speaker 2")]
    [SerializeField] private TMP_Text speakerName2;
    [SerializeField] private Image speakerImage2;

    [Header("UI -- Universal")]
    [SerializeField] private TMP_Text textLabel;

    [Header("Reference")]
    [SerializeField] private TypeWriterEffect typeWriterEffect;

    [Header("Panel")]
    [SerializeField] private GameObject dialoguePanel;

    private Coroutine dialogueCoroutine;
    private bool advancePressed;

    private void Start()
    {
        CloseDialogue();
        ShowDialogue(dialogueData);
    }

    public void ShowDialogue(DialogueSO dialogueSO)
    {
        dialoguePanel.SetActive(true);

        if(dialogueSO == null) return;

        if (dialogueCoroutine == null)
        {

            dialogueData = dialogueSO;

            SetUpDialogueUI_OnStart();

            dialogueCoroutine = StartCoroutine(StepThroughDialogue(dialogueSO));

        }
        else
        {
            Debug.Log("Dialogue lain lagi nyala");
        }
    }

    private IEnumerator StepThroughDialogue(DialogueSO dialogueSO)
    {
        foreach (Dialogue dialogue in dialogueSO.dialogueList)
        {
            SetUpDialogueUI_OnDialogue(dialogue);

            Coroutine typingRoutine = typeWriterEffect.Run(dialogue.dialogueText, textLabel);
            bool isTyping = true;
            advancePressed = false; // Reset input flag di awal tiap baris
            

            while (isTyping)
            {
                // Cek apakah tombol ditekan via Input Action (InputDialogueUI)
                if (advancePressed)
                {
                    advancePressed = false; // Consume input
                    typeWriterEffect.StopCoroutine(typingRoutine);
                    textLabel.text = dialogue.dialogueText;
                    isTyping = false;

                    yield return null;
                    break;
                }

                if (textLabel.text == dialogue.dialogueText)
                {
                    isTyping = false;
                }

                yield return null;
            }

            // Tunggu sampai input action dipanggil (advancePressed menjadi true)
            yield return new WaitUntil(() => advancePressed);
            advancePressed = false; // Reset flag setelah digunakan

            yield return null;
        }

        CloseDialogue();
    }

    public void CloseDialogue()
    {
        // Stop active coroutine if manually closing
        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;
        }

        ResetAllDialogueUI();
        dialoguePanel.SetActive(false);
        

    }

    private void ResetAllDialogueUI()
    {
        speakerName1.text = string.Empty;
        speakerName2.text = string.Empty;
        textLabel.text = string.Empty;
        speakerImage1.sprite = null;
        speakerImage2.sprite = null;
    }

    private void SetUpDialogueUI_OnStart()
    {
        if (!string.IsNullOrEmpty(dialogueData.speakerName1_Start))
        {
            speakerName1.text = dialogueData.speakerName1_Start;
            Sprite spriteSpeaker1 = DialogueManager.instance.GetSpeakerSprite(dialogueData.speakerName1_Start);
            if (spriteSpeaker1 != null)
            {
                speakerImage1.sprite = spriteSpeaker1;
            }
        }
        if (!string.IsNullOrEmpty(dialogueData.speakerName2_Start))
        {
            speakerName2.text = dialogueData.speakerName2_Start;
            Sprite spriteSpeaker2 = DialogueManager.instance.GetSpeakerSprite(dialogueData.speakerName2_Start);
            if (spriteSpeaker2 != null)
            {
                speakerImage2.sprite = spriteSpeaker2;
            }
        }
    }

    private void SetUpDialogueUI_OnDialogue(Dialogue dialogue)
    {
        if (!string.IsNullOrEmpty(dialogue.dialogueName))
        {
            Sprite newSprite = DialogueManager.instance.GetSpeakerSprite(dialogue.dialogueName);

            if (dialogue.onLeft)
            {
                speakerName1.text = dialogue.dialogueName;
                if (newSprite != null) speakerImage1.sprite = newSprite;
            }
            else
            {
                speakerName2.text = dialogue.dialogueName;
                if (newSprite != null) speakerImage2.sprite = newSprite;
            }
        }
        HighlightActiveSpeaker(dialogue.onLeft);
    }


    private void HighlightActiveSpeaker(bool isLeftSpeaking)
    {
        // Karakter aktif berwarna putih cerah, karakter pasif sedikit agak gelap/transparan
        Color activeColor = Color.white;
        Color inactiveColor = new Color(0.5f, 0.5f, 0.5f, 1f);

        if (speakerImage1 != null) speakerImage1.color = isLeftSpeaking ? activeColor : inactiveColor;
        if (speakerImage2 != null) speakerImage2.color = isLeftSpeaking ? inactiveColor : activeColor;
    }


    public void InputDialogueUI(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled)
        {
            advancePressed = true;
        }
    }

}
