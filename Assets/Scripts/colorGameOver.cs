using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class colorGameOver : MonoBehaviour {

	public List<Color> availableBackgrounds;

	// Use this for initialization
	void Start () {
		//picks random number in range
		int randomValue = Random.Range (0, availableBackgrounds.Count - 1);
		//sets color background
		this.gameObject.GetComponent<Image> ().color = availableBackgrounds [randomValue];
		//gives it to button
		GameObject.Find ("PlayButton").GetComponent<Image> ().color = this.gameObject.GetComponent<Image> ().color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
