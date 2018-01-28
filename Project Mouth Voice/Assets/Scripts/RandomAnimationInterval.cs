using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RandomAnimationInterval : MonoBehaviour {

	[SerializeField] private string triggerName;

	[SerializeField] private float minIntervalTime;
	[SerializeField] private float maxIntervalTime;
	private float timer;
	private float interval;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		interval = Random.Range(minIntervalTime, maxIntervalTime);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= interval) {
			animator.SetTrigger(triggerName);
			timer = 0f;
			interval = Random.Range(minIntervalTime, maxIntervalTime);
		}
	}
}
