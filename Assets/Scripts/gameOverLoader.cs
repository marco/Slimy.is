using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverLoader : MonoBehaviour {

	public GameObject lastScoreGO;
	public GameObject highScoreGO;
	public string lastScoreStarterText;
	public string highScoreStarterText;

	// Use this for initialization
	void Start () {
		lastScoreGO.GetComponent<Text> ().text = lastScoreStarterText + PlayerPrefs.GetInt ("lastScore").ToString ();
		highScoreGO.GetComponent<Text> ().text = highScoreStarterText + PlayerPrefs.GetInt ("highScore").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
