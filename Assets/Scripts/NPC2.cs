using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueSystem2 dialogueSystem;

    void Start() {
        dialogueSystem = FindObjectOfType<DialogueSystem2>();
	}

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            dialogueSystem.EnterRangeOfNPC();
		}
	}

    void Update() {
        if(dialogueSystem.withinRange && dialogueSystem.dialogueActive == false) {
             if(Input.GetKeyDown(KeyCode.F)) {
                dialogueSystem.StartDialogue(dialogue);            
			 }
		}
	}

    public void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            dialogueSystem.OutOfRangeOfNPC();  
		}
	}

}
