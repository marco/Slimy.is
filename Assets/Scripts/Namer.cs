using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Namer : MonoBehaviour {

	public List<string> adjectivesList;
	public List<string> nounsList;
	public float zValToAddToName;
	public GameObject namePrefab;

	// returns a random combination
	public string nameReturner(){
		//vars
		int randAdjNum = Random.Range (0, adjectivesList.Count - 1);
		int randNounNum = Random.Range (0, nounsList.Count - 1);
		//gets strings
		string randAdj = adjectivesList [randAdjNum];
		string randNoun = nounsList [randNounNum];
		//final (with space)
		string finalCombination = randAdj + " " +randNoun;
		//returns
		return finalCombination;
	}
	public void addNameTo(string nameToAdd, GameObject toAddTo){
			//gets position for name (with added z so it actually shows up)
			Vector3 namePosition = new Vector3 (toAddTo.GetComponent<Transform> ().position.x, toAddTo.GetComponent<Transform> ().position.y, toAddTo.GetComponent<Transform> ().position.z + zValToAddToName);
			//instantiates name
			GameObject newName = (GameObject)Instantiate (namePrefab, namePosition, Quaternion.identity);
			//sets sorting layer over Sprites
			newName.GetComponent<MeshRenderer>().sortingLayerName = "names";
			//sets parent
			newName.GetComponent<Transform> ().SetParent (toAddTo.GetComponent<Transform> ());
			//sets the name!
			newName.GetComponent<TextMesh> ().text = nameToAdd;
	}
}
