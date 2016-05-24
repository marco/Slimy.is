using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class playerRotator : MonoBehaviour {

	public float amountToMultiplyForRotation;
	public float amountToAddForRotation;
	public Vector3 currentRotation;

	// Update is called once per frame
	void FixedUpdate () {
		//if its the player....
		if (this.gameObject.tag == "player" && CrossPlatformInputManager.GetAxis ("Vertical") != 0 && CrossPlatformInputManager.GetAxis ("Horizontal") != 0) {
			//horizontal and vertical are X and Y position of joystick
			Vector2 joystickVector = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical"));
			//this crazy math just works to convert Vectors to Angles
			float mathValue = newAngleFromVector (joystickVector);
			//creates vector with mathValue
			Vector3 rotationVector = new Vector3 (0, 0, mathValue);
			//currentRotation
			currentRotation = rotationVector;
			//adds it to player head
			this.gameObject.GetComponent<Transform> ().eulerAngles = currentRotation;
		}
		else if (this.gameObject.tag == "player") {
			//adds it to player head
			this.gameObject.GetComponent<Transform> ().eulerAngles = currentRotation;
		}
	}
	float newAngleFromVector(Vector2 theVector){
		//idek
		float afterFirstFunction = Mathf.Atan2 (theVector.y, theVector.x);
		//this amount makes it spin at the right speed
		float multiplyByAmount = afterFirstFunction * amountToMultiplyForRotation;
		//pi is magical
		float divideByPi = multiplyByAmount / Mathf.PI;
		//adjust for default rotation
		float finalAnswer = divideByPi + amountToAddForRotation;
		//send
		return finalAnswer;
	}
}
