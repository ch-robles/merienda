using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController controller;
	public float speed = 2.5f;
	public float turnSmoothTime = 0.1f;
	public float turnSmoothVelocity;
	public Transform cam;
	public Animator playerAnim;


	public AudioSource footstep;
    public Manager manager;
    [Header("Animator")]

    public bool isGrounded = true;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    private Vector3 velocity;

	[Header("Torch Settings")]
	public GameObject torch;
    public KeyCode toggleKey = KeyCode.F; // Press F to toggle
	private bool torchOn = true;

	[Header("Tutorial Settings")]
	public bool canControl = false;

    // Start is called before the first frame update
    void Start()
    {
        // manager = FindObjectOfType<Manager>();
        playerAnim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
		if (!canControl) return;

		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

		/*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
		{
			footstep.enabled = true;
		}
		else
		{
			footstep.enabled = false;
		}*/

		if (torch != null && Input.GetKeyDown(toggleKey)){
            torchOn = !torchOn;
            torch.SetActive(torchOn); 
        }


		if (direction.magnitude >= 0.1f){
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * speed * Time.deltaTime);

		}

		if (direction.magnitude != 0) {
			//playerAnim.SetBool("isRunning", true);

		}

		if (direction.magnitude == 0){
			//playerAnim.SetBool("isRunning", false);
		}

		// Ground check 
		if (controller.isGrounded && velocity.y < 0){
			velocity.y = 0f;
			isGrounded = true;
		}

		// Jumping
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

			isGrounded = false;
		}

		if (isGrounded == false){
			playerAnim.SetBool("isJumping", true);
		}
		if (isGrounded == true){
			playerAnim.SetBool("isJumping", false);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);

	}
}
