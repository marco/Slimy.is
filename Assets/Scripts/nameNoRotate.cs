using UnityEngine;
using System.Collections;

public class nameNoRotate : MonoBehaviour {

	public GameObject theBackground;

	// Late so after normal update
	void LateUpdate () {
		Vector3 theParentPosition = this.gameObject.GetComponent<Transform> ().parent.gameObject.GetComponent<Transform>().position;
		this.gameObject.GetComponent<Transform> ().eulerAngles = new Vector3(0,0,0);
		this.gameObject.GetComponent<Transform> ().position = new Vector3 (theParentPosition.x, theParentPosition.y + theBackground.GetComponent<Namer> ().yValToAddToName, theParentPosition.z);
	}
}
