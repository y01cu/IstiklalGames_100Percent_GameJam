 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneAudio : MonoBehaviour
{
    public float maxThrottle = 1f;
    private float _throttle = 0f;
    public void SetThrottle(float newThrottle) => _throttle = newThrottle;
    
    [Header("Progressive Audios")]
    public ProgressiveAudio engineAudio;
    public ProgressiveAudio windAudio;

    private void Update()
    {
        ProgressAudios();
    }
    
    private void ProgressAudios()
    {
        float ratio = _throttle / maxThrottle;
        
        //Progress Engine Audio
        engineAudio.audioSource.volume = Mathf.Lerp(engineAudio.minVolume, engineAudio.maxVolume, ratio);
        engineAudio.audioSource.pitch = Mathf.Lerp(engineAudio.minPitch, engineAudio.maxPitch, ratio);
        
        //Progress Wind Audio
        windAudio.audioSource.volume = Mathf.Lerp(windAudio.minVolume, windAudio.maxVolume, ratio);
        windAudio.audioSource.pitch = Mathf.Lerp(windAudio.minPitch, windAudio.maxPitch, ratio);
    }
}
 
[Serializable]
public class ProgressiveAudio
{
    public AudioSource audioSource;
    public float minPitch;
    public float maxPitch;
    public float minVolume;
    public float maxVolume;
}
