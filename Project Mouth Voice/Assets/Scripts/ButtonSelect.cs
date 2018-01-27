using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour {

	private void OnEnable() {
		GetComponent<Button>().Select();
	}

}
