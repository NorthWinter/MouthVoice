using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

	private static List<Switch> mazeSwitches = new List<Switch>();
	public static MazeManager instance;

	// Use this for initialization
	void Awake () {
		instance = this;

		foreach(Switch mazeSwitch in GetComponentsInChildren<Switch>()) {
			mazeSwitches.Add(mazeSwitch);
		}

		foreach(Switch mazeSwitch in mazeSwitches) {
			mazeSwitch.gameObject.SetActive(false);
		}

		mazeSwitches[0].gameObject.SetActive(true);
	}

	public static void NextSwitch() {
		mazeSwitches[1].gameObject.SetActive(true);
		mazeSwitches.RemoveAt(0);
	}

	public static void ResetMaze() {
		mazeSwitches.Clear();
	}

}
