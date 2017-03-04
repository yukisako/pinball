using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;

	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		myHingeJoint = GetComponent<HingeJoint> ();
		SetAngle (this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)){
			SetAngle (this.defaultAngle);
		}

//		foreach (Touch touch in Input.touches) {
//			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
//				Debug.Log ("touch!!");
//			}
//		}


		//スマートフォンでも動かせるようにマルチタッチに対応しましょう
		foreach(Touch t in Input.touches)
		{
			if (t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled) {

				if (t.position.x > 190 && (tag == "RightFripperTag")) {
					SetAngle (this.flickAngle);
				}

				if (t.position.x <= 190 && (tag == "LeftFripperTag")) {
					SetAngle (this.flickAngle);
				}
			} else {
				SetAngle (this.defaultAngle);
			}

		}
	}

	private void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
		//ダメなの？
//		this.myHingeJoint.spring.targetPosition = angle;
	}
}
