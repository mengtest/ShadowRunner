using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpSpeed = 500f;
	private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Jump")){
			myRigidBody.AddForce(transform.up * jumpSpeed);
		}
	}
}
