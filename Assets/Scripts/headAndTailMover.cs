using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.CrossPlatformInput;

public class headAndTailMover : MonoBehaviour {

	public float speedPerUpdate;
	public createTails createTailsScript;
	private List<GameObject> partsList;
	private float tailOffset;
	public int amountToAddForMovement;
	public Vector3 currentMovement;
	public float amountToMultiplyLerp;
	public AIMover AIMoverScript;
	public float boostMultiplier;
	public float currentBoost;
	public float minimumScoreToBoost;
	public scorekeeper scorekeeperScript;
	public float boostLerpMultiply;
	private float currentBoostLerpMultiply;

	void Start () {
		//gets list of tails from createTailsScript
		partsList = createTailsScript.partsList;
		//gets offset
		tailOffset = createTailsScript.newTailOffset;
	}
	// Update is called once per frame
	void FixedUpdate () {
		//check if its being pressed
		if (CrossPlatformInputManager.GetButton ("Boost") == true && scorekeeperScript.currentScore >= minimumScoreToBoost) {
			//make the current boost into the maximum
			currentBoost = boostMultiplier;
			currentBoostLerpMultiply = boostLerpMultiply;
		}
		else {
			//make it have no multiplier
			currentBoost = 1;
			currentBoostLerpMultiply = 1;
		}
		//adds to heads (goes automatically because because it is "forwards" and "Space.Self")
		//moves camera with it, if player
		if (this.gameObject.tag == "player" && CrossPlatformInputManager.GetAxis ("Vertical") != 0 && CrossPlatformInputManager.GetAxis ("Horizontal") != 0) {
			//horizontal and vertical are X and Y position of joystick
			Vector2 joystickVector = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical"));
			//currentMovement
			currentMovement = joystickVector;
			//makes variables equal to things before moving stuff
			Vector3 headPosition = this.gameObject.GetComponent<Transform> ().position;
			Vector3 cameraPosition = Camera.main.GetComponent<Transform> ().position;
			//moves head (Space.World so it isnt affected by rotation)
			this.gameObject.GetComponent<Transform> ().Translate (currentMovement * speedPerUpdate * currentBoost, Space.World);
			//moves camera to X and Y of head, but not Z because that is depth
			Camera.main.GetComponent<Transform> ().position = new Vector3 (headPosition.x, headPosition.y, cameraPosition.z);
		}
		else if (this.gameObject.tag == "player") {
			//makes variables equal to things before moving stuff
			Vector3 headPosition = this.gameObject.GetComponent<Transform> ().position;
			Vector3 cameraPosition = Camera.main.GetComponent<Transform> ().position;
			//moves head (Space.World so it isnt affected by rotation
			this.gameObject.GetComponent<Transform> ().Translate (currentMovement * speedPerUpdate * currentBoost, Space.World);
			//moves camera to X and Y of head, but not Z because that is depth
			Camera.main.GetComponent<Transform> ().position = new Vector3 (headPosition.x, headPosition.y, cameraPosition.z);
		}
		if (this.gameObject.tag == "AI") {
			AIMoverScript.calculateHead(this.gameObject);
		}
		//go through every tail (start at 1 because head is 0)
		for (int i = 1; i < partsList.Count; i++) {
			//gets starting location
			Vector2 currentPosition = partsList[i].GetComponent<Transform>().position;
			//gets position of one in front
			Vector2 previousPosition = partsList[i - 1].GetComponent<Transform>().position;
			//gets difference
			Vector2 differenceVector = new Vector2(previousPosition.x - currentPosition.x, previousPosition.y - currentPosition.y);
			//move it
			moveTails(partsList[i], partsList[i - 1]);
		}
	}
	void moveTails(GameObject tailToMove, GameObject tailToFollow){
		//idek lerps r fun
		Vector3 tailToMoveVector = tailToMove.gameObject.GetComponent<Transform> ().position;
		Vector3 tailToFollowVector = tailToFollow.gameObject.GetComponent<Transform> ().position;
		//calculates difference between original and second
		//goes in the amount of speed per frame. amount multiplied is how close or far the tails are (1 is a whole tail away, 2 is half-way, etc.)
		tailToMove.gameObject.GetComponent<Transform>().position = new Vector2(Mathf.Lerp(tailToMoveVector.x, tailToFollowVector.x, speedPerUpdate * amountToMultiplyLerp * currentBoostLerpMultiply), Mathf.Lerp(tailToMoveVector.y, tailToFollowVector.y, speedPerUpdate * amountToMultiplyLerp * currentBoostLerpMultiply));
	}
}
