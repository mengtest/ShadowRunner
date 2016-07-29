using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpSpeed = 500f;
	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	private Collider2D myCollider;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		myCollider = GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Jump")){
			myRigidBody.AddForce(transform.up * jumpSpeed);
		}
		//setFloat method is used to increase th evVelocity component as we have made a 
		//transiion on value of vVelocity
		myAnim.SetFloat ("vVelocity", Mathf.Abs(myRigidBody.velocity.y));
	}



	//when something collides
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			//Application.LoadLevel(Application.loadedLevel);
			foreach(PrefabSpooner objPrefab in FindObjectsOfType<PrefabSpooner>()){
				objPrefab.enabled=false;
			}
			foreach(MoveLeft objMoveLeft in FindObjectsOfType<MoveLeft>()){
				objMoveLeft.enabled=false;
			}
			myAnim.SetBool("PlayerKilled", true);

			myRigidBody.velocity = Vector2.zero;
			myRigidBody.AddForce(transform.up * jumpSpeed);
			myCollider.enabled = false;
		}



	}

}
