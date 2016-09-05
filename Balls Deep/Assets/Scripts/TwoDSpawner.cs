using UnityEngine;
using System.Collections;

public class TwoDSpawner : MonoBehaviour {

    public float spawnRate;
    public GameObject[] gameObjects;

    private bool go;

	// Use this for initialization
	void Start () {
        go = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (go) {
            Invoke("SpawnObjects", spawnRate);
            go = false;
        }
	}

    void SpawnObjects() {
        foreach (Transform child in transform) { 
        int i;
        if (Random.value <= 0.2f) {
                if (Random.value <= 0.5) {
                    i = 0;
                } else { i = 1; }
        } else { i = 2; }

        GameObject thing = Instantiate(gameObjects[i], child.transform.position, Quaternion.identity) as GameObject;
        thing.transform.parent = child.transform; }

        go = true;
    }
}
