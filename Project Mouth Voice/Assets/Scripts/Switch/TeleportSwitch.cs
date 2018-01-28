using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSwitch : Switch {

	[SerializeField] private GameObject teleportLocations;
	[SerializeField] private AudioClip teleportSound;

	protected override void SwitchEffect() {
		base.SwitchEffect();

		AudioSource mazeAudio = MazeManager.instance.GetComponent<AudioSource>();

		mazeAudio.clip = teleportSound;
		mazeAudio.Play();
		player.transform.position = RandomLocation();
		CameraEffects.FadeOut();
		EndSwitch();
	}

	protected Vector2 RandomLocation() {
		BoxCollider2D chosenLocationBox = teleportLocations.GetComponents<BoxCollider2D>()[Random.Range(0, teleportLocations.GetComponents<BoxCollider2D>().Length)];
		float xPos = Random.Range(chosenLocationBox.offset.x - chosenLocationBox.size.x / 2, chosenLocationBox.offset.x + chosenLocationBox.size.x / 2);
		float yPos = Random.Range(chosenLocationBox.offset.y - chosenLocationBox.size.y / 2, chosenLocationBox.offset.y + chosenLocationBox.size.y / 2);
		return new Vector2(xPos, yPos);
	}
}
