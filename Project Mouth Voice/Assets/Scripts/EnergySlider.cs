using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour {

	[SerializeField] private PlayerController player;
	private Slider slider;

	[SerializeField] private AnimationCurve colorCurve;
	private Color startColor;
	private Image sliderImage;
	private float maxEnergy;

	// Use this for initialization
	void Awake () {
		maxEnergy = player.Energy;

		slider = GetComponent<Slider>();
		slider.maxValue = maxEnergy;
		sliderImage = slider.transform.GetChild(1).GetComponentInChildren<Image>();
		startColor = sliderImage.color;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = player.Energy;
		sliderImage.color = new Color(startColor.r, startColor.g, startColor.b, colorCurve.Evaluate(player.Energy / maxEnergy));
	}
}
