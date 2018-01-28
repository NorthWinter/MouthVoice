using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private enum Mode { Move, Turn, Scan}
	private Mode curMode = Mode.Scan;

	[SerializeField] private float damageOnHit;
	[SerializeField] private float turnAngle;
	[SerializeField] private AnimationCurve moveCurve;
	[SerializeField] private LayerMask detectionMask;
	private float moveTimer;
	private Vector2 startLocation;

	// Use this for initialization
	void Start () {
		startLocation = transform.position;
		StartCoroutine(AI());
	}
	
	private IEnumerator AI() {
		do {
			Debug.DrawLine((transform.position + transform.right / 4), (transform.position + 5 * transform.right / 4));
			switch (curMode) {
				case Mode.Move:
					moveTimer += Time.deltaTime;
					transform.position = startLocation + (Vector2)(transform.right * moveCurve.Evaluate(moveTimer));
					if(moveTimer >= moveCurve.keys[1].time) {
						curMode = Mode.Scan;
						moveTimer = 0f;
						startLocation = transform.position;
					}
					yield return null;
					break;
				case Mode.Turn:
					transform.Rotate(0, 0, turnAngle);
					curMode = Mode.Scan;
					yield return new WaitForSeconds(moveCurve.keys[1].time);
					break;
				case Mode.Scan:
					if(Physics2D.Linecast((transform.position + transform.right / 4), (transform.position + 5 * transform.right / 4), detectionMask)){
						curMode = Mode.Turn;
					} else {
						curMode = Mode.Move;
					}
					yield return null;
					break;
				default:
					yield return null;
					break;
			}
		} while (true);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.GetComponent<PlayerController>()) {
			collision.gameObject.GetComponent<PlayerController>().PlayerHit(damageOnHit);
		}
	}
}
