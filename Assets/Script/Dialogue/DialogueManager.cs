using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacterData
{
    public string characterName;
    public Sprite characterSprite;
}

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private List<DialogueCharacterData> dialogueCharacterDatas = new ();
    public List<DialogueCharacterData> DialogueCharacterDatas => dialogueCharacterDatas;

    public Sprite GetSpeakerSprite(string speakerName)
    {
        foreach(DialogueCharacterData data in dialogueCharacterDatas)
        {
            if(data.characterName == speakerName)
            {
                return data.characterSprite;
            }
        }
        return null;
    }

}
