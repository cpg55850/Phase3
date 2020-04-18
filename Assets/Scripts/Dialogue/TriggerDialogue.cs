using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public float lookRadius = 5f;
    private bool withinRange = false;
    
    Transform player;

    public Dialogue dialogue;
    private DialogueSystem dialogueSystem;

    void Start() {
        dialogueSystem = DialogueManager.instance.dialogueSystem.GetComponent<DialogueSystem>();
        player = PlayerManager.instance.player.transform;
	}

    void Update() {
        if(player) {
            float distance = Vector3.Distance(player.position, transform.position);

            if(distance <= lookRadius) {
                Vector3 targetToLookAt = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
                transform.LookAt(targetToLookAt);     
                if(Input.GetKeyDown(KeyCode.F) && dialogueSystem.dialogueActive == false) {
                    dialogueSystem.StartDialogue(dialogue);    
			    }
			}

            if (distance <= lookRadius && !withinRange) {
                withinRange = true;
                dialogueSystem.EnterRangeOfNPC();
		    }

            if (distance > lookRadius && withinRange) {
                withinRange = false;
                dialogueSystem.OutOfRangeOfNPC();     
			}
		}
	}
}
