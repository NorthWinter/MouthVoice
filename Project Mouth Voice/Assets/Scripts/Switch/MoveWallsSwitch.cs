using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallsSwitch : Switch {

	[SerializeField] private List<GameObject> wallsToMove = new List<GameObject>();

	protected override void SwitchEffect() {
		base.SwitchEffect();

		foreach(GameObject wall in wallsToMove) {
			wall.transform.Translate(Vector2.up);
		}
		CameraEffects.FadeOut();
		EndSwitch();
	}
}
