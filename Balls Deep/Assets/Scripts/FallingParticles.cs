using UnityEngine;
using System.Collections;

public class FallingParticles : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	     if(GameStateManager.currentState != GameStateManager.playState.falling) {
            Destroy(gameObject);
        }
	}
}
