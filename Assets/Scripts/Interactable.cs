using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
	}

    public virtual void Interact() {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
	}
}
