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
    private AudioSource audioSource;
    public AudioClip textClip;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueText.text = "";
        audioSource = gameObject.GetComponent<AudioSource>();
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
        animator.SetBool("IsOpen", false);
        promptGUI.SetActive(false);
        dialogueActive = false;
	}

    public void StartDialogue(Dialogue dialogue) {
        animator.SetBool("IsOpen", true);
        if (dialogueActive == false) {            
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
	}

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f); // wait for one frame
            if(letter != " ".ToCharArray()[0] && dialogueActive)
            {
                audioSource.PlayOneShot(textClip, .8f);
            }
        }
    }

    public void EndDialogue() {
        animator.SetBool("IsOpen", false);
        promptGUI.SetActive(true);
        dialogueActive = false;
	}

}
