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

	private void Awake() {
		body = GetComponent<Rigidbody2D>();
		walkSoundSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
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
		} else {
			if (walkSoundSource.isPlaying) {
				walkSoundSource.Stop();
			}
			walkSoundTimer = 1f;
		}
	}

	private void OnDisable() {
		body.velocity = Vector2.zero;

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
}
