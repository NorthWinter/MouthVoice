using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSwitch : Switch {

	[SerializeField] private Transform teleportLocation;
	[SerializeField] private AudioClip teleportSound;

	protected override void SwitchEffect() {
		base.SwitchEffect();

		AudioSource mazeAudio = MazeManager.instance.GetComponent<AudioSource>();

		mazeAudio.clip = teleportSound;
		mazeAudio.Play();
		player.transform.position = teleportLocation.position;
		CameraEffects.FadeOut();
		EndSwitch();
	}
}
