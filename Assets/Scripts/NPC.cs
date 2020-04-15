using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
	
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
		}
        
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
    }
}

