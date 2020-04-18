using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Singleton pattern
    #region Singleton

    public static DialogueManager instance;

    void Awake() {
        instance = this;
	}

    #endregion

    public GameObject dialogueSystem;
}
