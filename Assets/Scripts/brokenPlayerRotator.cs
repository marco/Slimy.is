using UnityEngine;
using System.Collections;

public class brokenPlayerRotator : MonoBehaviour {
	
	public float amountToChangeForRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			// Get position of the finger since last frame
			Vector2 lastTouchPosition = Input.GetTouch(0).position;

			if (this.gameObject.tag == "player") {
				//gets the "World Position" of where we touched
				Vector2 screenPositionOfTouch = getWorldPositionOfTouch(lastTouchPosition);
				//reduces it into a smaller Vector2
				Vector2 reducedScreenPosition = screenPositionOfTouch.normalized;
				//this crazy math just works
				float mathValue = Mathf.Atan2((reducedScreenPosition.y - Vector2.zero.y), (reducedScreenPosition.x - Vector2.zero.x)) * Mathf.Rad2Deg - amountToChangeForRotation; //was 90
				Quaternion quaternionValue = new Quaternion();
				quaternionValue.eulerAngles = new Vector3(0,0,mathValue);

				this.gameObject.GetComponent<Transform>().rotation = quaternionValue;

				//creates the Vector3 with mathValue
				//Vector3 mathValueVector3;
				//mathValueVector3.x = 0;
				//mathValueVector3.y = 0;
				//mathValueVector3.z = mathValue;
				//rotates the head (FINALLY)
				//this.gameObject.GetComponent<Transform>().eulerAngles = mathValueVector3;

				//prints amount of degrees
				//Debug.Log(mathValue);
			}
		}
	}
	Vector2 getWorldPositionOfTouch(Vector2 locationInScreenPoint){
		//gets the Main Camera
		Camera theCamera = Camera.main;
		//uses a function to convert the place I touched into a place in the world
		Vector3 newVector3 = theCamera.ScreenToWorldPoint(locationInScreenPoint);
		//converts that into a value we can use (Vector2)
		Vector2 vectorToReturn;
		vectorToReturn.x = newVector3.x;
		vectorToReturn.y = newVector3.y;
		//outputs the new Vector2
		return vectorToReturn;
	}
}
