using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateSwitch : Switch {

	[SerializeField] private List<GameObject> toRemove;

	protected override void TriggerSwitch() {

	}

	protected override void SwitchEffect() {

		foreach(GameObject thing in toRemove) {
			Destroy(thing);
		}

		EndSwitch();
	}

}
