using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	protected PlayerController player;

	private void OnEnable() {
		CameraEffects.FadeInComplete += SwitchEffect;
		player = FindObjectOfType<PlayerController>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag == "Player") {
			TriggerSwitch();
		}
	}

	virtual protected void TriggerSwitch() {
		if(GetComponent<AudioSource>() != null) {
			GetComponent<AudioSource>().Play();
		}
		CameraEffects.FadeIn();
		player.enabled = false;
	}

	virtual protected void SwitchEffect() {
		MazeManager.instance.GetComponent<AudioSource>().Play();
	}

	protected void EndSwitch() {
		MazeManager.NextSwitch();
		player.enabled = true;
		Destroy(gameObject);
	}

	protected void OnDisable() {
		CameraEffects.FadeInComplete -= SwitchEffect;
	}

}
