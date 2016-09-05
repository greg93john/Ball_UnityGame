using UnityEngine;
using System.Collections;

public class StartingPlayfield : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (GameStateManager.currentState == GameStateManager.playState.falling) {
            DestroyPlayfield();
        }
	}

    void DestroyPlayfield() {
        Destroy(gameObject);
    }
}
