using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {

	Material myMaterial;

	private float minEmmision = 0.3f;

	private float magEmmission = 2.0f;

	private int degree = 0;

	private int speed = 10;

	Color defaultColor = Color.white;

	// Use this for initialization
	void Start () {
		if (tag == "SmallStarTag") {
			this.defaultColor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultColor = Color.yellow;
		} else if (tag == "SmallCloudTag" || tag == "SmallCloudTag") {
			this.defaultColor = Color.blue;
		}

		this.myMaterial = GetComponent<Renderer> ().material;
		myMaterial.SetColor ("_EmissionColor", this.defaultColor * minEmmision);

	}
	
	// Update is called once per frame
	void Update () {
		if (this.degree >= 0) {
			Color emissionColor = this.defaultColor * (this.minEmmision + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmmission);
			myMaterial.SetColor ("_EmissionColor", emissionColor);
			this.degree -= speed;
		}
	}

	void OnCollisionEnter(Collision other){
		this.degree = 180;
	}

}
