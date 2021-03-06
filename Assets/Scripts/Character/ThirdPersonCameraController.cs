﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform target, player;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        if(player){
            target.transform.position = player.transform.position + new Vector3(0, 2.5f, 0);
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);
            transform.LookAt(target);

            if (Input.GetKey(KeyCode.LeftAlt))
            {
                target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            } else
            {
                target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
                player.rotation = Quaternion.Euler(0, mouseX, 0);
            }
		}
        

	}
}
