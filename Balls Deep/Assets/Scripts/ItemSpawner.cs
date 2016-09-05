using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public GameObject pickUpPrefab;
    public GameObject emptySpace;
    public float spawnDelay;

    private bool go;

	// Use this for initialization
	void Start () {
        go = false;
        Invoke("SpawnPickUps", spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameStateManager.currentGameStyle == GameStateManager.gameStyle.collect) {
            
        } else {
            
        }

        if (AllMembersGone() && go) {
            LevelStateManagerScript.levelEnd = true;
        }
    }

    public void SpawnPickUps() {
        bool spawning = true;
        foreach (Transform child in transform) {
            if (spawning && Random.Range(0, 1f) < 0.5f) {
                Debug.Log("Should be spawning an pickup object.");
                GameObject pickUp = Instantiate(pickUpPrefab, child.transform.position, Quaternion.identity) as GameObject;
                pickUp.transform.parent = child.transform;
            }
        }

        if (AllMembersGone()) {
            SpawnPickUps();
        } else {
            go = true;
        }
    }

    Transform NextFreePosition() {
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount == 0) {
                return childPositionGameObject;
            }
        }
        return null;
    }

    public void CheckIfAllGone() {
        if (AllMembersGone() && (GameStateManager.currentGameStyle == GameStateManager.gameStyle.collect)) {
            LevelStateManagerScript.levelDone = true;
        }
    }

    bool AllMembersGone() {
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount > 0) {
                return false;
            }
        }
        return true;
    }
}
