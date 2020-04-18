using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    private Queue<string> sentences;
    private bool inRange;

    public Text nameText;
    public Text dialogueText;
    public GameObject promptGUI;
    public GameObject dialogueGUI;
    public bool dialogueActive = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueText.text = "";
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.F) && dialogueActive == true) {
              DisplayNextSentence();
		}
	}

    public void EnterRangeOfNPC() {
        promptGUI.SetActive(true);
	}

    public void OutOfRangeOfNPC() {
        dialogueGUI.SetActive(false);
        promptGUI.SetActive(false);
        dialogueActive = false;
	}

    public void StartDialogue(Dialogue dialogue) {
        if(dialogueActive == false) {
            dialogueGUI.SetActive(true);
            promptGUI.SetActive(false);
            dialogueActive = true;

            nameText.text = dialogue.name;

            sentences.Clear();

            foreach(string sentence in dialogue.sentences){
                sentences.Enqueue(sentence);  
		    }
		}
	}

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
		}

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
	}

    public void EndDialogue() {
        promptGUI.SetActive(true);
        dialogueGUI.SetActive(false);
        dialogueActive = false;
	}

}
