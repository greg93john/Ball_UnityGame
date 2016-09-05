using UnityEngine;
using System.Collections;

public class ParticleSpawner : MonoBehaviour {

    public GameObject particlePrefab;

    private bool go;
	
	// Update is called once per frame
	void Update () {
        if (GameStateManager.currentState == GameStateManager.playState.falling && go) {
            SpawnParticles();
            go = false;
        } else if(GameStateManager.currentState != GameStateManager.playState.falling) {
            go = true;
        }
	}

    void SpawnParticles() {
        GameObject particles = Instantiate(particlePrefab, transform.position,Quaternion.identity) as GameObject;
        particles.transform.parent = transform;
    }
}
