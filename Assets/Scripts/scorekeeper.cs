using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.CrossPlatformInput;

public class scorekeeper : MonoBehaviour {

	public int currentScore = 0;
	private int lastCheckedScore = 0;
	public createTails createTailsScript;
	private List<GameObject> partsList;
	public int scoreForNewTail;
	private float boostTimer;
	public float secondsBetweenBoostPenalty;
	public int boostPenalty;
	public GameObject theScoreBoard;
	public headAndTailMover headAndTailMoverScript;

	// Use this for initialization
	void Start () {
		theScoreBoard = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//sees if there are extra score that havent been added to our tail yet
		if (currentScore - scoreForNewTail >= lastCheckedScore) {
			//makes the NEW highest score
			lastCheckedScore += scoreForNewTail;
			//makes the new tail
			createTailsScript.createANewTail();
		}

		//keeps boostTimer up to date
		boostTimer += Time.deltaTime;
		//if it's time to check
		if(boostTimer >= secondsBetweenBoostPenalty){
			//reset
			boostTimer = 0;
			//if its acrually being pressed... found in other script (if the current boost is the maximum boost)
			if(headAndTailMoverScript.currentBoost == headAndTailMoverScript.boostMultiplier){
				//subtracts
				currentScore -= boostPenalty;
				//checks if it's player
				if(this.gameObject.tag == "player"){
					//gets component from using UnityEngine.UI (and also uses function to convert to string)
					theScoreBoard.GetComponent<Text>().text = currentScore.ToString();
				}
			}
		}
	}

	public void addToCurrentScore(int amountToAdd){
		//if this is an AI
		if (this.gameObject.tag == "AI") {
			//shorthand for add
			currentScore += amountToAdd;
		}
		//if it's the player
		if (this.gameObject.tag == "player") {
			//makes sure it has the scoreboard
			theScoreBoard = GameObject.Find("Score");
			//adds
			currentScore += amountToAdd;
			//gets component from using UnityEngine.UI (and also uses function to convert to string)
			theScoreBoard.GetComponent<Text>().text = currentScore.ToString();
		}
	}
}
