using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die() {
        Debug.Log("The enemy died.");
        AudioSource.PlayClipAtPoint(gameObject.GetComponent<EnemyAI>().owClip, gameObject.transform.position);
        Destroy(gameObject);
    }
}
