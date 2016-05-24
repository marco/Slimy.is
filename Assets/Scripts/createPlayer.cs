﻿using UnityEngine;
using System.Collections;

public class createPlayer : MonoBehaviour {

	public createStartingAI createStartingAIScript;
	public GameObject headsPrefab;
	public Vector2 startingPosition;

	// Use this for initialization
	void Start () {

		//get createStartingAIScript from background.		//createStartingAIScript = this.gameObject.GetComponent (typeof(createStartingAI)) as createStartingAI;
		headsPrefab = createStartingAIScript.headsPrefab;

		createANewHead ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void createANewHead(){
		//finds position for new head
		Vector2 currentPosition = startingPosition;
		//creates head & makes it a GameObject & tag
		GameObject newHead = Instantiate (headsPrefab, currentPosition, Quaternion.identity) as GameObject;
		newHead.gameObject.tag = "player";
		//rotates (90 because that is how tail faces at start)
		newHead.gameObject.GetComponent<Transform> ().eulerAngles = new Vector3 (0, 0, 90);
		//colors
		colorHead (newHead);
	}
	void colorHead(GameObject currentHead){
		//gets sprite rendering part and changes the color value
		//"(typeof(SpriteRenderer)) as SpriteRenderer" makes sure there are no errors
		SpriteRenderer headSprite = currentHead.GetComponent<SpriteRenderer>();
		//headSprite.color = AIColors [currentHead];
	}
}