using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class OptionalAdManager : MonoBehaviour {
	
	public string gameId;
	public bool enableTest;
	public string zone;
	public int scoreForWatchingAd;

	public void adPressed(){
		//gets ad ready
		Advertisement.Initialize (gameId, enableTest);
		//starts
		StartCoroutine("startAdShow");
	}
	
	IEnumerator startAdShow(){
		//while it's not ready...
		while (!Advertisement.IsReady()) {
			//i don't understand yields
			yield return null;
		}
		//then finally
		Advertisement.Show(zone);
		//add to score
		PlayerPrefs.SetInt ("extraScore", scoreForWatchingAd);
	}
}
