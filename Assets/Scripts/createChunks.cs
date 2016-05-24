using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class createChunks : MonoBehaviour {

	public List<GameObject> chunkList;
	public GameObject chunkPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createChunksInList(List<GameObject> partsList){
		for (int p = 0; p < partsList.Count; p++) {
			GameObject newChunk = (GameObject)Instantiate (chunkPrefab, partsList[p].gameObject.GetComponent<Transform>().position, Quaternion.identity);
			newChunk.gameObject.tag = "chunk";
			chunkList.Add (newChunk);
		}
	}

}
