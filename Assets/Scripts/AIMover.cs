using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.CrossPlatformInput;

public class AIMover : MonoBehaviour {

	public float maxChunkDistance;
	public float maxDotDistance;
	public float minChunkDistance;
	public float minDotDistance;
	private GameObject itemGoingTo = null;
	public headAndTailMover headAndTailMoverScript;
	private float speedPerUpdate;
	public scorekeeper scorekeeperScript;
	public bool AICanBoost;

	public void calculateHead(GameObject head){
		//gets speed
		speedPerUpdate = headAndTailMoverScript.speedPerUpdate;
		//it becomes null if destroyed, so...
		if (itemGoingTo == null) {
			//gets every "dot" and "chunk " in an array
			GameObject[] dotsArray = GameObject.FindGameObjectsWithTag("dot");
			GameObject[] chunksArray = GameObject.FindGameObjectsWithTag("chunk");
			//if there is a viable chunk...
			if(getBestChunk(chunksArray) != null){
				itemGoingTo = getBestChunk(chunksArray);
				if(scorekeeperScript.currentScore >= headAndTailMoverScript.minimumScoreToBoost && AICanBoost){
					headAndTailMoverScript.currentBoost = headAndTailMoverScript.boostMultiplier;
				}
			}
			//if not, go with a dot
			else{
				itemGoingTo = getBestDot(dotsArray);
				headAndTailMoverScript.currentBoost = 1;
			}
		}
		//gets Vector2 of itemGoingTo
		Vector2 itemGoingToVector2 = itemGoingTo.gameObject.GetComponent<Transform> ().position;
		//gets Vector2 of AI
		Vector2 AIVector2 = this.gameObject.GetComponent<Transform> ().position;
		//moves towards
		head.GetComponent<Transform> ().position = Vector2.MoveTowards (AIVector2, itemGoingToVector2, speedPerUpdate / headAndTailMoverScript.currentBoost);
	}

	GameObject getBestChunk(GameObject[] chunkList){
		//goes through every one
		for (int i = 0; i < chunkList.Length; i++) {
			//finds distance between AI and dot
			float distanceBetween = Vector3.Distance(chunkList[i].GetComponent<Transform>().position, this.gameObject.GetComponent<Transform>().position);
			//if the distance is less than the maximum, and more than the minimum, return it
			if (distanceBetween >= minChunkDistance && distanceBetween <= maxChunkDistance){
				//change the current one to go for to be this one
				return chunkList[i];
			}
		}
		//send out nothing if it hasn't been found yet
		return null;
	}
	GameObject getBestDot(GameObject[] dotList){
		//goes through every one
		for (int i = 0; i < dotList.Length; i++) {
			//finds distance between AI and dot
			float distanceBetween = Vector3.Distance(dotList[i].GetComponent<Transform>().position, this.gameObject.GetComponent<Transform>().position);
			//if the distance is less than the maximum, and more than the minimum, return it
			if (distanceBetween >= minDotDistance && distanceBetween <= maxDotDistance){
				//change the current one to go for to be this one
				return dotList[i];
			}
		}
		//send out nothing if it hasn't been found yet
		return null;
	}
}
