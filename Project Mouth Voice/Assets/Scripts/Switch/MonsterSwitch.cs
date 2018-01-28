using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSwitch : Switch {

	[SerializeField] private GameObject despawnedEnemy;
	[SerializeField] private GameObject spawnedEnemy;

	protected override void TriggerSwitch() {
		
	}

	protected override void SwitchEffect() {
		base.SwitchEffect();

		Destroy(despawnedEnemy);
		spawnedEnemy.SetActive(true);
		EndSwitch();
	}
}
