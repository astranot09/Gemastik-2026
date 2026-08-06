using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CutsceneManager : MonoBehaviour
{

    [SerializeField] private List<Sprite> cutsceneSprites = new ();

    [Header("Animation")]
    [SerializeField] private float delayBeforeCutsceneStart = 1f;

    void Start()
    {
        CutsceneStart();
    }

    public void CutsceneStart()
    {

    }

}
