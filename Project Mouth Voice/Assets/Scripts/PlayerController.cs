using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float speed = 1f;

	private Rigidbody2D body;

	private AudioSource walkSoundSource;

	private List<AudioClip> walkSounds = new List<AudioClip>();
	private float walkSoundTimer = 1f;

	[SerializeField] private float energy;
	public float Energy { get { return energy; } }

	private Animator animator;
	private SpriteRenderer sprite;

	private bool isDamaged = false;

	private void Awake() {
		body = GetComponent<Rigidbody2D>();
		walkSoundSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}

	private void OnEnable() {
		animator.enabled = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!isDamaged) {
			body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
		}
	}

	private void Update() {
		if(energy <= 0f) {
			CameraEffects.Failure();
			enabled = false;
		}
		if(body.velocity.magnitude > .1f) {
			energy -= body.velocity.magnitude / speed * Time.deltaTime;
			walkSoundTimer += Time.deltaTime * (body.velocity.magnitude / speed);
			if (walkSoundTimer >= .3f) {
				walkSoundSource.clip = RandomWalkSound(walkSounds);
				walkSoundSource.Play();
				walkSoundTimer = 0f;
			}
			animator.Play("Walk");
			sprite.flipX = body.velocity.x > 0;
		} else {
			if (walkSoundSource.isPlaying) {
				walkSoundSource.Stop();
			}
			walkSoundTimer = 1f;
			if (!isDamaged) {
				animator.Play("Idle");
			}
		}
	}

	private void OnDisable() {
		body.velocity = Vector2.zero;
		animator.Play("Idle");
		if (walkSoundSource.isPlaying) {
			walkSoundSource.Stop();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.GetComponent<ZoneEffects>()) {
			walkSounds = collision.gameObject.GetComponent<ZoneEffects>().walkSounds;
		}
	}

	private AudioClip RandomWalkSound(List<AudioClip> walkSounds) {
		return walkSounds[Random.Range(0, walkSounds.Count)];
	}

	public void PlayerHit(float damage) {
		energy -= damage;
		body.velocity = Vector2.zero;
		StartCoroutine(Damaged());
		GetComponent<Animator>().Play("Hit");
	}

	private IEnumerator Damaged() {
		isDamaged = true;
		yield return new WaitForSeconds(.5f);
		isDamaged = false;
	}
}
