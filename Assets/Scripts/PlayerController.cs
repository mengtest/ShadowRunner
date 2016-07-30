using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float jumpSpeed = 500f;
	public AudioSource jumpSfx;
	public AudioSource deathSfx;
	public Text ScoreText;

	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	private Collider2D myCollider;
	private float startTime;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		myCollider = GetComponent<Collider2D> ();

		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		ScoreText.text = (Time.time - startTime).ToString ("0.0");
		if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Jump")){
			myRigidBody.AddForce(transform.up * jumpSpeed);
			jumpSfx.Play();
		}
		//setFloat method is used to increase th evVelocity component as we have made a 
		//transiion on value of vVelocity
		myAnim.SetFloat ("vVelocity", Mathf.Abs(myRigidBody.velocity.y));
	}



	//when something collides
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {

			foreach(PrefabSpooner objPrefab in FindObjectsOfType<PrefabSpooner>()){
				objPrefab.enabled=false;
			}
			foreach(MoveLeft objMoveLeft in FindObjectsOfType<MoveLeft>()){
				objMoveLeft.enabled=false;
			}
			myAnim.SetBool("PlayerKilled", true);

			myRigidBody.velocity = Vector2.zero;
			deathSfx.Play();
			myRigidBody.AddForce(transform.up * jumpSpeed);
			myCollider.enabled = false;

			Application.LoadLevel(Application.loadedLevel);

		}



	}

}
