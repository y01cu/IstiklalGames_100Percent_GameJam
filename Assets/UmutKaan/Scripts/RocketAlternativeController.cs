using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class RocketAlternativeController : MonoBehaviour {
    private Rigidbody rigidbody;

    private bool isUpForceReadyToApply = false;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator Start() {
        yield return new WaitForSeconds(1f);
        isUpForceReadyToApply = true;
    }

    private void FixedUpdate() {
        if (isUpForceReadyToApply) {
            rigidbody.AddForce(transform.up * 40f);
        }
        rigidbody.AddForce(transform.forward * 5f);
    }
}