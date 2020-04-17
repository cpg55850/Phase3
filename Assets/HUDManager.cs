using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    CharacterStats myStats;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start() {
        myStats = PlayerManager.instance.player.gameObject.GetComponent<CharacterStats>();
	}

    private void LateUpdate() {
        // Health HUD
        for(int i = 0; i < hearts.Length; i++) {
            if(i < myStats.currentHealth) {
                hearts[i].sprite = fullHeart;     
			} else {
                hearts[i].sprite = emptyHeart;     
			}

            if(i < myStats.maxHealth) {
                hearts[i].enabled = true;
		    } else {
                hearts[i].enabled = false;
		    }
	    }
	}
}
