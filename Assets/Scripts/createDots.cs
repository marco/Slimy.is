using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class createDots : MonoBehaviour {

	public int amountOfDotsPerRound;
	public float secondsBetweenRounds;
	private float timer = 0;
	public GameObject map;
	public List<Color> dotColors;
	public GameObject dotPrefab;

	// Use this for initialization
	void Start () {
		//so we get a first batch
		timer = secondsBetweenRounds;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//removes time that has past from timer (time since last frame)
		timer += Time.deltaTime;
		if (timer >= secondsBetweenRounds) {
			//goes back to 0
			timer = 0;
			//gets all current dots
			GameObject[] dotsArray = GameObject.FindGameObjectsWithTag("dot");
			//sees if we need to add some
			if(dotsArray.Length < amountOfDotsPerRound){
				//adds them 
				addDots(amountOfDotsPerRound - dotsArray.Length);
			}
		}
	}
	void addDots(int amountToAdd){
		//you understand for's, right?
		for(int i = 0; i < amountToAdd; i++){
			//gets random location
			Vector3 mapSize = map.GetComponent<Renderer>().bounds.size;
			//gets floats based on half of map (because MIDDLE is 0, 0)
			float halfMapX = mapSize.x / 2;
			float halfMapY = mapSize.y / 2;
			//gets random location on map X between -halfMap and halfMap (0, 0 is center so it is half on each side)
			float rand0To1X = Random.Range(-halfMapX, halfMapX);
			float rand0To1Y = Random.Range(-halfMapY, halfMapY);
			//makes a vector3 out of values
			Vector3 randomVector3 = new Vector3(rand0To1X, rand0To1Y, 0);
			//makes it and tags
			GameObject newDot = (GameObject)Instantiate (dotPrefab, randomVector3, Quaternion.identity);
			newDot.gameObject.tag = "dot";
			//colors!
			//gets SpriteRenderer, accesses color attribute, and then picks a random option from the dotColors array (0 duh, and dotColors.Count - 1 because count is one more than last item)
			newDot.GetComponent<SpriteRenderer>().color = dotColors[Random.Range(0, dotColors.Count - 1)];
		}
	}
}
