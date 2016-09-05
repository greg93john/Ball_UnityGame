using UnityEngine;
using System.Collections;

public class PlayfieldTracker : MonoBehaviour {

    // public variables
    public GameObject[] Playfield;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnNewPlayfield() {
        if (GameStateManager.currentState == GameStateManager.playState.twoD) {
            GameObject spawningField = Instantiate(Playfield[0], transform.position, Quaternion.identity) as GameObject;
            spawningField.transform.parent = transform;
        } else if(GameStateManager.currentState == GameStateManager.playState.threeD) {
            GameObject spawningField = Instantiate(Playfield[1], transform.position, Quaternion.identity) as GameObject;
            spawningField.transform.parent = transform;
        }
    }
}
