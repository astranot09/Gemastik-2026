using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    [Header("Source")]
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SFX;

    [Header("Clip BGM")]
    [SerializeField] private AudioClip bgmClip;

    [Header("Clip BGM")]
    [SerializeField] public AudioClip dayFinished;


    private void Start()
    {
        PlayBGM(bgmClip);
    }

    public void PlayBGM(AudioClip clip)
    {
        Debug.Log("music");
        if(clip != null && BGM != null)
        {
            Debug.Log("play music");
            BGM.clip = clip;
            BGM.loop = true;
            BGM.Play();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && SFX != null)
        {
            SFX.PlayOneShot(clip);
        }
    }

}
