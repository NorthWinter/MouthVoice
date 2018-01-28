using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallsSwitch : Switch {

	[SerializeField] private List<GameObject> wallsToMove = new List<GameObject>();
	[SerializeField] private AudioClip wallMoveSound;

	protected override void SwitchEffect() {
		base.SwitchEffect();

		AudioSource mazeAudio = MazeManager.instance.GetComponent<AudioSource>();

		mazeAudio.clip = wallMoveSound;
		mazeAudio.Play();

		foreach (GameObject wall in wallsToMove) {
			wall.transform.Translate(Vector2.up * 4);
		}
		CameraEffects.FadeOut();
		EndSwitch();
	}
}
