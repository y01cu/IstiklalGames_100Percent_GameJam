using System.Collections;
using System.Collections.Generic;
using EasyButtons;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    public AudioSource explosionAudioSource;
    public AudioClip explosionAudioClip;
    private Coroutine _spawnExplosionCoroutine;
    
    [Button]
    public void SpawnExplosion(Vector3 position)
    {
        if (_spawnExplosionCoroutine != null)
            StopCoroutine(_spawnExplosionCoroutine);
        
        _spawnExplosionCoroutine = StartCoroutine(SpawnExplosionCoroutine(position));
    }
    
    public IEnumerator SpawnExplosionCoroutine(Vector3 position)
    {
        explosionAudioSource.PlayOneShot(explosionAudioClip);
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(explosion);
    }
}
