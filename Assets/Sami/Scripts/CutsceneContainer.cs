using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneContainer", menuName = "CutsceneContainer", order = 1)]
public class CutsceneContainer : ScriptableObject
{
    public CutsceneData[] cutsceneData;
}

