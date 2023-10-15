using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour
{
    public Transform propellerRPivot;
    public Transform propellerLPivot;
    public Rigidbody planeRigidbody;
    
    void Update()
    {
        if (planeRigidbody.velocity.magnitude > 10)
        {
            propellerRPivot.Rotate(Vector3.forward * 1000 * Time.deltaTime);
            propellerLPivot.Rotate(Vector3.forward * 1000 * Time.deltaTime);
        }
    }
}
