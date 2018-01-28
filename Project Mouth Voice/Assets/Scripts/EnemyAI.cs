using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private enum Mode { Move, Turn }
	private Mode curMode = Mode.Move;

	[SerializeField] private float damageOnHit;
	[SerializeField] private float turnTime;
	[SerializeField] private float turnAngle;
	private float curAngle;
	private Vector2 moveVector = Vector2.right;
	[SerializeField] private AnimationCurve moveCurve;
	[SerializeField] private LayerMask detectionMask;
	private float moveTimer;
	private Vector2 startLocation;

	[SerializeField] private AudioSource hitSound;
	private Animator animator;

	// Use this for initialization
	void Start () {
		startLocation = transform.position;

		animator = GetComponent<Animator>();
		StartCoroutine(AI());
	}
	
	private IEnumerator AI() {
		do {
			Debug.DrawLine((transform.position + (Vector3)moveVector / 4), (transform.position + 5 * (Vector3)moveVector / 4));
			switch (curMode) {
				case Mode.Move:
					if(moveTimer == 0f) {
						animator.Play("Move");
					}
					moveTimer += Time.deltaTime;
					transform.position = startLocation + (moveVector * moveCurve.Evaluate(moveTimer));
					if(moveTimer >= moveCurve.keys[1].time) {
						if (Physics2D.Linecast((transform.position + (Vector3)moveVector / 4), (transform.position + 5 * (Vector3)moveVector / 4), detectionMask)) {
							curMode = Mode.Turn;
						} else {
							curMode = Mode.Move;
						}
						moveTimer = 0f;
						startLocation = transform.position;
					}
					yield return null;
					break;
				case Mode.Turn:
					animator.Play("Idle");
					curAngle += turnAngle;
					moveVector = new Vector2(Mathf.Cos(Mathf.Deg2Rad * curAngle), Mathf.Sin(Mathf.Deg2Rad * curAngle));
					GetComponent<SpriteRenderer>().flipX = moveVector.x < 0;
					if (Physics2D.Linecast((transform.position + (Vector3)moveVector / 4), (transform.position + 5 * (Vector3)moveVector / 4), detectionMask)) {
						curMode = Mode.Turn;
					} else {
						curMode = Mode.Move;
					}
					yield return new WaitForSeconds(turnTime);
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
			hitSound.Play();
		}
	}
}
