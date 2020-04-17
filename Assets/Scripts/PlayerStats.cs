using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Update() {
        if(Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(1);  
		}
	}

    public override void Die() {
        Debug.Log("The player died. Health is " + currentHealth);
        Destroy(gameObject);
	}
}
