using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartLocation : MonoBehaviour {

	[SerializeField] private Transform player;

	// Use this for initialization
	void Start () {
		BoxCollider2D chosenLocationBox = GetComponents<BoxCollider2D>()[Random.Range(0, GetComponents<BoxCollider2D>().Length)];
		float xPos = Random.Range(chosenLocationBox.offset.x - chosenLocationBox.size.x / 2, chosenLocationBox.offset.x + chosenLocationBox.size.x / 2);
		float yPos = Random.Range(chosenLocationBox.offset.y - chosenLocationBox.size.y / 2, chosenLocationBox.offset.y + chosenLocationBox.size.y / 2);
		player.transform.position = new Vector2(xPos, yPos);
	}
	
}
