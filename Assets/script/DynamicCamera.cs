using UnityEngine;

public class DynamicCamera : MonoBehaviour {

	public Transform target;
	public float smooth = 5.0f;
	Vector3 offset;

	void Start () {
		offset = transform.position + target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(target.position, targetCamPos, smooth*Time.deltaTime);



	}
}
