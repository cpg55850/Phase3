using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardForce : MonoBehaviour
{
    public AudioClip bounce;
    public AudioSource audioSource;

    // Applies an upwards force to all rigidbodies that enter the trigger.
    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.up * 100);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(bounce, 0.5f);
            }
            
        }
    }
}
