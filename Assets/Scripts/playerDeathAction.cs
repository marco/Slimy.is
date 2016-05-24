using UnityEngine;
using System.Collections;

public class playerDeathAction : MonoBehaviour {

	// Use this for initialization
	void headKilled(GameObject headThatDied){
		if (headThatDied.tag == "player") {
			Debug.Log("rekt");
		}
		else if(headThatDied.tag == "AI"){
			Debug.Log("aww");
		}
	}
}
