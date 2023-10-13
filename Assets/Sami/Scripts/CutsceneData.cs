using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneData", menuName = "CutsceneData", order = 1)]
public class CutsceneData : ScriptableObject
{
    public float triggerDistance;
    [TextArea(3, 10)] public string subtitle;
    public AudioClip audioClip;
    
    public void PlayCutscene()
    {
        CutsceneManager.Instance.PlayCutscene(this);
    }

    public Sprite sadaf;
}