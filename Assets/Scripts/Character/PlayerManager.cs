using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Singleton pattern
    #region Singleton

    public static PlayerManager instance;

    void Awake() {
        instance = this;
	}

    #endregion

    public GameObject player;
    private bool isWalking;
    private IEnumerator coroutine;
    public AudioSource clip;


}
