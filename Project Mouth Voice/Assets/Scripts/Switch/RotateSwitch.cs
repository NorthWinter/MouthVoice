using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSwitch : Switch {

	[SerializeField] private float angle = 90;

	protected override void SwitchEffect() {
		base.SwitchEffect();

		transform.parent.rotation = Quaternion.Euler(0, 0, angle);
		player.transform.rotation = Quaternion.Euler(0, 0, 0);
		CameraEffects.RotateFadeOut();
		EndSwitch();
	}

}
