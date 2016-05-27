using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Namer : MonoBehaviour {

	public List<string> adjectivesList;
	public List<string> nounsList;

	// returns a random combination
	string nameReturner(){
		//vars
		int randAdjNum = Random.Range (0, adjectivesList.Count);
		int randNounNum = Random.Range (0, nounsList.Count);
		//gets strings
		string randAdj = adjectivesList [randAdjNum];
		string randNoun = nounsList [randNounNum];
		//final
		string finalCombination = randAdj + randNoun;
		//returns
		return finalCombination;
	}
}
