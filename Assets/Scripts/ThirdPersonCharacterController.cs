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

    public float damage = 10f;
    public float range;
    private int layerMask;

    CharacterStats myStats;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        range = 3f;
        layerMask = LayerMask.GetMask("Interactable");
        myStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walking animation
        PlayerMovement();

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = 20f;
		} else {
            speed = 10f;  
		}

        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        // Punch
        if(Input.GetMouseButtonDown(0)) {
            Punch();
		}

        // MakeCube
        if(Input.GetMouseButtonDown(1)) {
            MakeCube();  
		}
        //Debug.DrawRay(this.transform.position + new Vector3(0, 2, 0), this.transform.forward * range, Color.red, 0f, false);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 7f, Color.blue, 0f, false);
        

    }

    void Punch() {
        anim.Play("Punch",-1,0f);
        RaycastHit hit;
        bool didHit = Physics.Raycast(this.transform.position + new Vector3(0, 2, 0), cam.transform.forward * 7f, out hit, range, layerMask);

        if(didHit) {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(this.transform.position + new Vector3(0, 2, 0), cam.transform.forward * 7f, Color.yellow, 200f, false);
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable) {
                 interactable.Interact();
			} else {
                hit.rigidbody.AddForce(cam.transform.forward * 1000f);
            }
		}
	}

    void MakeCube() {
        GameObject player = this.gameObject;
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 10f;

        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
        GameObject instantiatedObj = Instantiate(upCube, spawnPos, playerRotation);
        Destroy(instantiatedObj, 5f);
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
