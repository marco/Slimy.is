using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class youAreChecker : MonoBehaviour {

	public string fillerText;

	// Use this for initialization
	int findCurrentNumber(GameObject theObject){
		//gets all heads
		List<GameObject> allAIHeads = new List<GameObject> ();
		allAIHeads.AddRange(GameObject.FindGameObjectsWithTag("AI").ToList());
		//vars
		int amountBetter = 0;
		//for every ai
		for (int i = 0; i < allAIHeads.Count; i++) {
			//if they have more tails
			if(allAIHeads[i].GetComponent<createTails>().partsList.Count > theObject.GetComponent<createTails>().partsList.Count){
				//there is one more better than you!
				amountBetter++;
			}
		}
		//you are in 1-moreth place than the amount better than you
		return amountBetter + 1;
	}
	void Update(){
		//gets variable
		GameObject player = GameObject.FindGameObjectWithTag ("player");
		//sets text based on function
		this.GetComponent<Text>().text = fillerText + findCurrentNumber (player);
	}
}
