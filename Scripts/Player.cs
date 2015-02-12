/* Baseline class for a movement mechanic using a cube character moving along a fixed grid */
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Animator animator;
	public float speed = 1.0f;
	
	private Vector3 endpos;
	private bool moving = true;
	private bool leftPressed = false;
	
	void Start () {
		endpos  = transform.position;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			leftPressed = true;
		} else if (Input.GetKeyUp (KeyCode.A)) {
			leftPressed = false;
		}
		if (moving && (transform.position == endpos)) {
			Debug.Log ("DOING");
			if(Input.GetKey(KeyCode.A) && leftPressed) {
				leftPressed = false;
				StartCoroutine(RotationPause());
				return;
			}
			endpos = transform.position + transform.forward;

		}
		
		transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
	}

	IEnumerator RotationPause() {
		moving = false;
		animator.speed = 0;
		yield return new WaitForSeconds (0.25f);
		transform.Rotate (0, 90, 0);
		moving = true;
		animator.speed = 1;
	}
	
}
