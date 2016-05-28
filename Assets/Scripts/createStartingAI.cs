using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class createStartingAI : MonoBehaviour {

	//doesn't create the player!
	
	public int startingAmount;
	public List<GameObject> AIList;
	public List<Vector2> startingPositions;
	public List<Color> AIColors;
	public GameObject headsPrefab;
	public GameObject namePrefab;
	public int amountOfAIPerRound;
	public float secondsBetweenRounds;
	private float timer = 0;
	public float zValToAddToName;
	public int startingAIScore;

	// Use this for initialization
	void Start () {
		//goes through every head to be made
		for (int i = 0; i < startingAmount; i++) {
			createANewHead(i);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//removes time that has past from timer (time since last frame)
		timer += Time.deltaTime;
		if (timer >= secondsBetweenRounds) {
			for(int i = 0; i < amountOfAIPerRound; i++){
				//timer goes back to 0
				timer = 0;
				//creates a new, random head (-1 for random)
				createANewHead(-1);
			}
		}
	}

	public void createANewHead(int currentHead){
		//new head position
		Vector3 currentPosition;
		//currentStartingScore
		int currentStartingScore;
		//if we want a random one...
		if (currentHead == -1) {
			//gets random location
			Vector3 mapSize = this.GetComponent<Renderer> ().bounds.size;
			//gets floats based on half of map (because MIDDLE is 0, 0)
			float halfMapX = mapSize.x / 2;
			float halfMapY = mapSize.y / 2;
			//gets random location on map X between -halfMap and halfMap (0, 0 is center so it is half on each side)
			float rand0To1X = Random.Range (-halfMapX, halfMapX);
			float rand0To1Y = Random.Range (-halfMapY, halfMapY);
			//makes a vector3 out of values
			currentPosition = new Vector3 (rand0To1X, rand0To1Y, 0);
			currentStartingScore = 0;
		
		}
		else {
			//finds position for new head
			currentPosition = startingPositions [currentHead];
			//sets beginning score for beginniing ai
			currentStartingScore = startingAIScore;
		}
		//does these things no matter what
		//creates head & tags & adds to list
		GameObject newHead = (GameObject)Instantiate (headsPrefab, currentPosition, Quaternion.identity);
		newHead.gameObject.tag = "AI";
		AIList.Add (newHead);
		//rotates (90 because that is how tail faces at start)
		newHead.gameObject.GetComponent<Transform> ().eulerAngles = new Vector3 (0, 0, 90);
		//scores
		newHead.gameObject.GetComponent<scorekeeper>().currentScore = currentStartingScore;
		//colors
		colorHead (newHead);
		//names
		addName (newHead);
	}
	void colorHead(GameObject currentHead){
		//gets sprite rendering part and changes the color value
		//"(typeof(SpriteRenderer)) as SpriteRenderer" makes sure there are no errors
		SpriteRenderer headSprite = currentHead.GetComponent<SpriteRenderer>();
		headSprite.color = AIColors [Random.Range(0, AIColors.Count - 1)];
	}
	void addName(GameObject currentHead){
		string theName = this.GetComponent<Namer>().nameReturner();
		this.GetComponent<Namer>().addNameTo(theName, currentHead);
	}
	void colorNewAI(GameObject newHead){
		SpriteRenderer headSprite = newHead.GetComponent<SpriteRenderer>();
		headSprite.color = AIColors [Random.Range(0, AIColors.Count - 1)];
	}
}
