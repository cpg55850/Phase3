using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonCharacterController : MonoBehaviour
{

    public float speed = 10f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private CapsuleCollider col;
    public LayerMask ground;
    private bool doubleJump = false;
    private Animator anim;
    public GameObject upCube;

    public int health;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walking animation
        PlayerMovement();

        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        // Punch
        if(Input.GetMouseButtonDown(0)) {
            Punch();
		}

        // Health

        if(health > maxHealth) {
            health = maxHealth;  
		}

        for(int i = 0; i < hearts.Length; i++) {
            if(i < health) {
                hearts[i].sprite = fullHeart;     
			} else {
                hearts[i].sprite = emptyHeart;     
			}

            if(i < maxHealth) {
                hearts[i].enabled = true;
		    } else {
                hearts[i].enabled = false;
		    }
	    }


    }

    void Punch() {
                    anim.Play("Punch",-1,0f);

            GameObject player = this.gameObject;
            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Quaternion playerRotation = player.transform.rotation;
            float spawnDistance = 10f;

            Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
            Instantiate(upCube, spawnPos, playerRotation);
	}

    void PlayerMovement() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if(Input.GetKeyDown(KeyCode.Space)) {
            if(IsGround()) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                doubleJump = false;
			}

            if(!IsGround() && !doubleJump) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                doubleJump = true;     
			}
		}
	}

    private bool IsGround() {
        bool isGround = Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius, ground);
        return isGround;
	}
}
