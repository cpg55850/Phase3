using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Interactable
{
    public float lookRadius = 10f;

    Transform player;
    NavMeshAgent agent;
    public AudioClip owClip;
    public AudioSource audioSource;

    CharacterStats myStats;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        myStats = GetComponent<CharacterStats>();
    }

    // Function that runs when the player interacts with the enemy
    public override void Interact() {
        CharacterCombat playerCombat = player.gameObject.GetComponent<CharacterCombat>();
        if (playerCombat != null) {
            playerCombat.Attack(myStats);
		}

        if (audioSource.enabled)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(owClip, 0.3f);
        }

	}

    // Update is called once per frame
    void Update()
    {
        if(player) {
                      float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRadius) {
            agent.SetDestination(player.position);
            Vector3 targetToLookAt = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            transform.LookAt(targetToLookAt);  
		} else {
            agent.SetDestination(transform.position);  
		}
		}

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
