using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class ForcedAdManager : MonoBehaviour {
	
	public string gameId;
	public bool enableTest;
	public int randRange;

	
	void Start(){
		//gets ad ready
		Advertisement.Initialize (gameId, enableTest);
		
		//gets a random number in range
		int randomNum = Random.Range (0, randRange);
		//checks if we should display ad
		if (randomNum == 0) {
			//idk
			StartCoroutine("startAdShow");
		}
	}
	
	IEnumerator startAdShow(){
		//while it's not ready...
		while (!Advertisement.IsReady()) {
			//i don't understand yields
			yield return null;
		}
		//then finally
		Advertisement.Show();
	}
}
