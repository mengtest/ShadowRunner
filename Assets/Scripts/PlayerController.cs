using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpSpeed = 500f;
	private Rigidbody2D myRigidBody;
	private Animator myAnim;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Jump")){
			myRigidBody.AddForce(transform.up * jumpSpeed);
		}

		myAnim.SetFloat ("vVelocity", Mathf.Abs(myRigidBody.velocity.y));
	}
}
