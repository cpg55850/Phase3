using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardForce : MonoBehaviour
{
    // Applies an upwards force to all rigidbodies that enter the trigger.
    void OnTriggerStay(Collider other) {
        if (other.attachedRigidbody)
            other.attachedRigidbody.AddForce(Vector3.up * 100);
	}
}
