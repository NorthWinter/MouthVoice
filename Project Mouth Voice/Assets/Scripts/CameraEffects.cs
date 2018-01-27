using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraEffects : MonoBehaviour {

	private static Animator animator;

	public delegate void CameraEvent();
	public static event CameraEvent FadeInComplete;

	private void Start() {
		animator = GetComponent<Animator>();
	}

	public static void FadeIn() {
		animator.Play("Fade In");
	}

	public static void FadeOut() {
		animator.Play("Fade Out");
	}

	public static void RotateFadeOut() {
		animator.Play("Rotate Fade Out");
	}

	public static void EndGame() {
		animator.Play("End Game");
	}

	public static void Failure() {
		animator.Play("Failure");
	}

	public void TriggerFadeInComplete() {
		if(FadeInComplete != null) {
			FadeInComplete();
		}
	}

	public void ResetGame() {
		FadeInComplete = null;
		MazeManager.ResetMaze();
		SceneManager.LoadScene(0);
	}
}

