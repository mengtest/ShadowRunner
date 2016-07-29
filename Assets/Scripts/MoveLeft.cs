using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//deltaTime = time used to com,plete last update
		transform.position += Vector3.left * speed * (Time.deltaTime);
	}
}
