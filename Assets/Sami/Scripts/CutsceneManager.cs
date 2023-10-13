using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public CutsceneContainer cutsceneContainer;
    
    private static CutsceneManager _instance;

    public static CutsceneManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<CutsceneManager>();
            return _instance;
        }
    }
    
    private AudioSource _audioSource;
    public TMP_Text subtitleText;
    
    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayCutscene(0);
        
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayCutscene(1);
        
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            PlayCutscene(2);
    }

    public void TryPlayCutscene(CutsceneData cutsceneData, Transform start, Transform target)
    {
        if (Vector3.Distance(start.position, target.position) < cutsceneData.triggerDistance)
            cutsceneData.PlayCutscene();
    }
    
    public void PlayCutscene(CutsceneData cutsceneData)
    {
        StartCoroutine(PlayCutsceneCoroutine(cutsceneData));
    }
    
    public void PlayCutscene(int cutsceneIndex)
    {
        StartCoroutine(PlayCutsceneCoroutine(cutsceneContainer.cutsceneData[cutsceneIndex]));
    }

    private IEnumerator PlayCutsceneCoroutine(CutsceneData cutsceneData)
    {
        float fadeTime = 0.5f;
        float elapsedTime = 0f;
        
        subtitleText.text = cutsceneData.subtitle;
        //Text Fade In
        while (elapsedTime < fadeTime)
        {
            subtitleText.color = new Color(subtitleText.color.r, subtitleText.color.g, subtitleText.color.b, elapsedTime / fadeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        //Play Audio
        _audioSource.clip = cutsceneData.audioClip;
        _audioSource.Play();
        yield return new WaitForSeconds(cutsceneData.audioClip.length);
        _audioSource.Stop();
        
        
        elapsedTime = 0f;
        
        //Text Fade Out
        while (elapsedTime < fadeTime)
        {
            subtitleText.color = new Color(subtitleText.color.r, subtitleText.color.g, subtitleText.color.b, 1 - elapsedTime / fadeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
