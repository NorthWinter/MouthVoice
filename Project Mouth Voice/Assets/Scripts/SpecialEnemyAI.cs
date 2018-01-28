using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyAI : EnemyAI {

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag == "Respawn") {
			turnAngle *= -1;
		}
	}
}
