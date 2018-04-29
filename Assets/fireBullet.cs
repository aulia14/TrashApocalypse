using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {
	public float timeBetweenBullets = 0.15f;
	public GameObject projectile;
	float nextBullet;
	// Use this for initialization
	void Start () {
		nextBullet = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController myPlayer = transform.root.GetComponent <PlayerController> ();
	}
}
