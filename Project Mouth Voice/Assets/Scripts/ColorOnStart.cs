using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnStart : MonoBehaviour {

	[SerializeField] private Color startColor;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = startColor;
	}

}
