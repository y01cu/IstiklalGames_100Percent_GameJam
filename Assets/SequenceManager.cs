using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SequenceManager : MonoBehaviour
{
    public FadeManager fadeManager;
    public TMP_Text blackScreenText;
    public CinemachineDollyCart cart;
    public CinemachineVirtualCamera cinemachineCamera;
    public Animator atat;
    public Transform plane;

    private void Start()
    {
        StartCoroutine(IntroSequence());
    }

    public IEnumerator IntroSequence()
    {
        //fadeManager.FadeOut(0.2f);
        
        StartCoroutine(TypewriteText("Türkiye Cumhuriyeti Devleti 1937 yılında, satın aldığı veya savaş sonucu elde ettiği uçakları kullanarak mücadele vermekteydi..."));
        yield return new WaitForSeconds(5f);
        fadeManager.StartFadeIn();
        cart.m_Speed = 10f;
        blackScreenText.text = "";

        yield return new WaitUntil(() => cart.m_Position > 65);

        cinemachineCamera.LookAt = atat.transform;
        atat.Play("Atat");
        
        
        yield return new WaitUntil(() => cart.m_Position > 110);
        cinemachineCamera.LookAt = plane.transform;
        atat.gameObject.SetActive(false);
        
        
        yield return new WaitUntil(() => cart.m_Position >= 143);
        cinemachineCamera.Follow = plane;
        cinemachineCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 15, -20);
    }
    

    private IEnumerator TypewriteText(string text)
    {
        float elapsedTime = 0f;
        float timePerCharacter = 0.01f;
        int characterIndex = 0;
        string currentText = "";
        
        while (characterIndex < text.Length)
        {
            currentText += text[characterIndex];
            blackScreenText.text = currentText;
            characterIndex++;
            yield return new WaitForSeconds(timePerCharacter);
        }
    }
}