using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraRotationHandler : MonoBehaviour {
    
    
    
    // private float rollInput;
    // [SerializeField] private float rotationSpeed;
    // private CinemachineVirtualCamera virtualCamera;
    //
    // private void Awake() {
    //     virtualCamera = GetComponent<CinemachineVirtualCamera>();
    // }
    //
    // private void Update() {
    //     GetRollInput();
    //     RotateCinemachineVirtualCameraBasedOnRollInput();
    // }
    //
    // private void GetRollInput() {
    //     rollInput = Input.GetAxis("Horizontal");
    // }
    //
    // private void RotateCinemachineVirtualCameraBasedOnRollInput() {
    //     float rotationAmount = rollInput * rotationSpeed * Time.deltaTime;
    //     virtualCamera.transform.Rotate(0, 0, rotationAmount);
    // }
}