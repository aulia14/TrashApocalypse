using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	void OnCollisionEnter(Collision collision)
	{
		
		Debug.Log ("On Collision Enter");

		if(collision.gameObject.name == "Enemy" )
		{
			Destroy (collision.gameObject);
		}
	}
	void OnTriggerEnter(Collider col)
	{

		Debug.Log ("On Collider Enter");

		if(col.gameObject.name == "Enemy" )
		{
			Destroy (col.gameObject);
		}
	}

}
 	