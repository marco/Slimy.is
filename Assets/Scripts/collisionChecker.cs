using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class collisionChecker : MonoBehaviour {

	public createTails createTailsScript;
	private List<GameObject> currentHeadPartsList; 
//	public playerDeathAction playerDeathActionScript;
	public GameObject background;
	public GameObject headPrefab;
	public createChunks createChunksScript;
	public scorekeeper scorekeeperScript;
	public int scoreForDot;
	public int scoreForChunk;

	void Start(){
		currentHeadPartsList = createTailsScript.partsList;
	}

	void FixedUpdate(){
		//checks using separate methods
		checkDots ();
		checkTails ();
		checkChunks ();
		checkBounds ();
	}
	void checkDots(){
		//vars (headBounds HAS TO BE IN HERE DONT MOVE IT)
		Bounds headBounds = this.gameObject.GetComponent<Renderer> ().bounds;
		GameObject[] dotArray = GameObject.FindGameObjectsWithTag("dot");
		//finds if intersecting any dots
		for (int d = 0; d < dotArray.Length; d++) {
			//gets current dot bounds
			Bounds currentDotBounds = dotArray[d].gameObject.GetComponent<Renderer>().bounds;
			//check if we intersect with them
			if(headBounds.Intersects(currentDotBounds)){
				scorekeeperScript.addToCurrentScore(scoreForDot);
				Destroy(dotArray[d].gameObject);
			}
		}
	}
	void checkChunks(){
		//vars (headBounds HAS TO BE IN HERE DONT MOVE IT)
		Bounds headBounds = this.gameObject.GetComponent<Renderer> ().bounds;
		GameObject[] chunkArray = GameObject.FindGameObjectsWithTag("chunk");
		//finds if intersecting any dots
		for (int c = 0; c < chunkArray.Length; c++) {
			//gets current dot bounds
			Bounds currentChunkBounds = chunkArray[c].gameObject.GetComponent<Renderer>().bounds;
			//check if we intersect with them
			if(headBounds.Intersects(currentChunkBounds)){
				scorekeeperScript.addToCurrentScore(scoreForChunk);
				Destroy(chunkArray[c].gameObject);
			}
		}
	}
	void checkTails(){
		//vars
		Bounds headBounds = this.gameObject.GetComponent<Renderer> ().bounds;
		GameObject[] tailArray = GameObject.FindGameObjectsWithTag("tail");
		//finds if intersecting any dots
		for (int t = 0; t < tailArray.Length; t++) {
			//gets current dot bounds
			Bounds currentTailBounds = tailArray[t].gameObject.GetComponent<Renderer>().bounds;
			//check if we intersect with them
			if(headBounds.Intersects(currentTailBounds)){
				//check that it's not OUR TAIL (if the current heads list of tails doesnt have this tail in it)
				if(currentHeadPartsList.Contains(tailArray[t]) != true){
					thisKilled();
				}
			}
		}
	}
	void checkBounds(){
		//gets map
		GameObject map = GameObject.Find("background");
		//gets this
		Bounds headBounds = this.gameObject.GetComponent<Renderer> ().bounds;
		//if the head is off the map
		if (headBounds.Intersects (map.GetComponent<Renderer> ().bounds) == false) {
			thisKilled();
		}
	}
	void thisKilled(){
		if(this.gameObject.tag == "AI"){
			//get the current tails and pass them into this function to make chunks at their location
			createChunksScript.createChunksInListWithColor(currentHeadPartsList, this.GetComponent<SpriteRenderer>().color);
			Destroy(this.gameObject);
		}
		else if(this.gameObject.tag == "player"){
			Destroy(this.gameObject);
			//set saved last score as this score
			PlayerPrefs.SetInt("lastScore", this.GetComponent<scorekeeper>().currentScore);
			//if the last score is higher than the highscore
			if(PlayerPrefs.GetInt("lastScore") > PlayerPrefs.GetInt("highScore")){
				//set the highscore to the last score
				PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("lastScore"));
			}
			//go to scene
			Application.LoadLevel("GameOver");
		}
		//go through all of our tails
		for(int p = 0; p < currentHeadPartsList.Count; p++){
			//and destroy them too
			Destroy(currentHeadPartsList[p]);
		}
	}
}
