using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSwitch : Switch {

	protected override void TriggerSwitch() {
		player.enabled = false;
		CameraEffects.EndGame();
	}

}
