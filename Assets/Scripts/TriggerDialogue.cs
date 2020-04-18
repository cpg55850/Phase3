using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public float lookRadius = 5f;
    
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

            if (distance <= lookRadius) {
                dialogueSystem.EnterRangeOfNPC();

                Vector3 targetToLookAt = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
                transform.LookAt(targetToLookAt);
                if(Input.GetKeyDown(KeyCode.F) && dialogueSystem.dialogueActive == false) {
                    dialogueSystem.StartDialogue(dialogue);    
			    }
		    } else {
                dialogueSystem.OutOfRangeOfNPC();    
			}
		}



	}

}
