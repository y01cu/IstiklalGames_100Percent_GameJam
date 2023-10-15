using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private Image _spriteRenderer;
    private float _duration = 0.2f;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<Image>();
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn(_duration));
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut(_duration));
    }
    
    public IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - elapsedTime / duration;
            _spriteRenderer.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
        
        _spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
    }
    
    public IEnumerator FadeOut(float duration)  
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = elapsedTime / duration;
            _spriteRenderer.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
        
        _spriteRenderer.color = new Color(0f, 0f, 0f, 1f);
    }
}
