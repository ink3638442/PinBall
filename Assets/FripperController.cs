using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;
	
	private float flickAngle = -20;


	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint>();

		SetAngle(this.defaultAngle);	
	}
	
	// Update is called once per frame
	void Update () {
		// キーボード入力用
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle(this.flickAngle);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle(this.flickAngle);
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle(this.defaultAngle);
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle(this.defaultAngle);
		}

		// スマホ入力用
		for (int i = 0; i < Input.touches.Length; i++) {
			if (Input.touches[i].phase == TouchPhase.Began) {
				if (Input.touches[i].position.x < Screen.width / 2 && tag == "LeftFripperTag") {
					SetAngle(this.flickAngle);
				}

				if (Input.touches[i].position.x >= Screen.width / 2 && tag == "RightFripperTag") {
					SetAngle(this.flickAngle);
				}
			}

			if (Input.touches[i].phase == TouchPhase.Ended) {
				if (Input.touches[i].position.x < Screen.width / 2 && tag == "LeftFripperTag") {
					SetAngle(this.defaultAngle);
				}

				if (Input.touches[i].position.x >= Screen.width / 2 && tag == "RightFripperTag") {
					SetAngle(this.defaultAngle);
				}
			}
		}
	}

	public void SetAngle(float angle) {
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
