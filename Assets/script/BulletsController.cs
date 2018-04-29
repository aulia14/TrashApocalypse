using UnityEngine;


public class BulletsController : MonoBehaviour {

	public Rigidbody bullets;

	void FixedUpdate () {

		if (Input.GetButtonDown("Fire1")) {
			Rigidbody clone;
			clone = Instantiate(bullets, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.right * 10);
		}
			
	}



}
