using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSwitch : Switch {

	[SerializeField] private Transform teleportLocation;

	protected override void SwitchEffect() {
		base.SwitchEffect();

		player.transform.position = teleportLocation.position;
		CameraEffects.FadeOut();
		EndSwitch();
	}
}
