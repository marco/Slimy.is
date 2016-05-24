using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class createTails : MonoBehaviour {

	public int minimumParts;
	public List<GameObject> partsList;
	public GameObject tailsPrefab;
	public float newTailOffset;

	// Use this for initialization
	void Start () {
		//puts current head into partsList
		partsList.Add (this.gameObject);

		//adds needed tails
		for (int i = 0; i < minimumParts; i++) {
			createANewTail();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createANewTail () {
		//creates offset place for tail
		//gets previous tail location
		Vector2 lastTailPosition;
		lastTailPosition = partsList[partsList.Count - 1].transform.position;
		//makes new one
		Vector2 newTailPosition;
		newTailPosition = lastTailPosition;
		newTailPosition.x = newTailPosition.x + newTailOffset;
		//creates tail & makes it a GameObject & adds to list
		GameObject newTail = (GameObject)Instantiate (tailsPrefab, newTailPosition, Quaternion.identity);
		newTail.gameObject.tag = "tail";
		partsList.Add (newTail);
		//makes it show up on bottom (negative is lower)
		newTail.GetComponent<SpriteRenderer> ().sortingOrder = -partsList.Count;
		//color
		colorTail (newTail);
	}
	void colorTail(GameObject currentTail){
		//gets sprite rendering part and changes the color value
		//"(typeof(SpriteRenderer)) as SpriteRenderer" makes sure there are no errors
		SpriteRenderer tailSprite = currentTail.GetComponent<SpriteRenderer>();
		//first item in partsList is head
		SpriteRenderer headSprite = partsList[0].GetComponent<SpriteRenderer>();
		//headsprite has already been set in background script, so this makes it the same
		tailSprite.color = headSprite.color;
	}
}
