using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class brokenHeadAndTailMover : MonoBehaviour {

	public createTails createTailsScript;
	private List<GameObject> partsList;
	public float speedPerUpdate;
	public float amountToChangeFromRotation;

	// Use this for initialization
	void Start () {
		partsList = createTailsScript.partsList;
	}
	
	// Update is called once per frame
	void Update () {
		//z is the only axis rotated on, and this is how much it is rotated
		float amountOfZRotation = this.gameObject.GetComponent<Transform> ().eulerAngles.z;
		//converts angle to radians
		float amountOfZRadians = amountOfZRotation * Mathf.Deg2Rad;
		//converts radians to Vector2
		Vector2 amountOfZVector2 = new Vector2(Mathf.Cos(amountOfZRadians) + amountToChangeFromRotation, Mathf.Sin(amountOfZRadians) + amountToChangeFromRotation);
		//reduces it
		Vector2 reducedZVector2 = amountOfZVector2.normalized;
		//moves head
		this.gameObject.GetComponent<Transform>().Translate (reducedZVector2 * speedPerUpdate);
		//moves camera with it, if player
		if (this.gameObject.tag == "player") {
			//makes variables equal to things before moving camera
			Vector3 headPosition = this.gameObject.GetComponent<Transform> ().position;
			Vector3 cameraPosition = Camera.main.GetComponent<Transform> ().position;
			//moves camera to X and Y of head, but not Z because that is depth
			Camera.main.GetComponent<Transform> ().position = new Vector3 (headPosition.x, headPosition.y, cameraPosition.z);
		}

		//go through every tail
		//start at 1 because we already moved head and it is 0;
//		for (int i = 1; i < partsList.Count; i++) {
//			//vars
//			GameObject currentTail = partsList[i];
//			Vector2 currentTailPosition = currentTail.GetComponent<Transform>().position;
//			GameObject lastTail = partsList[i - 1];
//			Vector2 lastTailPosition = lastTail.GetComponent<Transform>().position;
//			//this crazy math just works
//			float mathValue = Mathf.Atan2((currentTailPosition.y - lastTailPosition.y), (currentTailPosition.x - lastTailPosition.x)) * Mathf.Rad2Deg - 90;
//			//puts it in a Vector3
//			Vector3 mathValueVector3;
//			mathValueVector3.x = 0;
//			mathValueVector3.y = 0;
//			mathValueVector3.z = mathValue;
//			//rotates the tail (FINALLY)
//			currentTail.gameObject.GetComponent<Transform>().eulerAngles = mathValueVector3;
//			//moves the tail
//			//Transform.up is the axis the tails should move on
//			Vector3 upVector3 = this.gameObject.GetComponent<Transform>().up;
//			//creates a Vector2 out of the Vector3
//			Vector2 upVector2 = new Vector2(upVector3.x, upVector3.y);
//			//moves head
//			this.gameObject.GetComponent<Transform>().Translate(upVector2 * speedPerUpdate);
//		}
	}
}
