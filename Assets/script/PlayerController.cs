using UnityEngine;


public class PlayerController : MonoBehaviour {
	//public CharacterController controler;
//	private float verticalVelocity;
//	private float gravity = 14.0f;
//	private float jumpForce = 10.0f;
	public float runSpeed ;
	public float walkSpeed;
	Animator myAnim;
	Rigidbody myRB;
	bool facingRight = true;

	public float jumpHeight;
	Collider[] collisionObject;
	public Transform CheckGround;
	public LayerMask GroundLayer;
	bool grounded;
	float groundCheckRadious = 0.2f;

	void Start()
	{

		myAnim = GetComponent<Animator> ();
		myRB = GetComponent<Rigidbody> ();
		facingRight = true;
	}

	void FixedUpdate()
	{

//		if(controler.isGrounded)
//		{
//			verticalVelocity = -gravity * Time.deltaTime;
//			if (Input.GetKeyDown (KeyCode.Space)) {
//				verticalVelocity = jumpForce;
//			}
//		} else {
//			verticalVelocity -= gravity * Time.deltaTime;
//		}
		//Vector3 moveVector = new Vector3 (0, verticalVelocity, 0);
//		Vector3 moveVector = Vector3.zero;
//		moveVector.x = Input.GetAxis ( "Horizontal")*5.0f;
//		moveVector.y = verticalVelocity;
//		controler.Move (moveVector * Time.deltaTime);

		if (grounded && Input.GetAxis ("Jump")>0){
			grounded = false;
			myAnim.SetBool ("grounded", grounded);
			myRB.AddForce (new Vector3 (0, jumpHeight, 0));

		}



		collisionObject = Physics.OverlapSphere (CheckGround.position, groundCheckRadious, GroundLayer);
		if(collisionObject.Length>0) grounded = true;
		else grounded = false;

		myAnim.SetBool("grounded",grounded);

		float move = Input.GetAxis("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		float sneaking = Input.GetAxisRaw("Fire3");
		myAnim.SetFloat("sneaking", sneaking);

		if(sneaking>0 && grounded){
			myRB.velocity = new Vector3 (move * walkSpeed, myRB.velocity.y, 0);
		}else{
			myRB.velocity = new Vector3 (move * runSpeed, myRB.velocity.y, 0);
		}
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	
	
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.z *= -1;
		transform.localScale = theScale;
	}

	public float GetFacing(){
		if (facingRight)
			return 1;
		else
			return -1;
	}



}
