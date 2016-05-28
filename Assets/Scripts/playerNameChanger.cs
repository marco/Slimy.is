using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerNameChanger : MonoBehaviour {

	public InputField nameInput;

	// input changed to is set inside unity
	public void playerNameChanged(){
		PlayerPrefs.SetString ("userName", nameInput.text);
	}
}
