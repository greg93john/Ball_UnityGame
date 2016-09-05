using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public float spawnDelay;
    public GameObject enemyPrefab;
    public GameObject emptySpace;

	// Use this for initialization
	void Start () {
        Invoke("SpawnEnemies", spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void SpawnEnemies() {
        bool spawning = true;
        foreach (Transform child in transform) {
            if (spawning && Random.Range(0, 1f) < 0.5f) {
                Debug.Log("Should be spawning an enemy object.");
                GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child.transform;
            }
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

    bool AllMembersDead() {
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount > 0) {
                return false;
            }
        }
        return true;
    }

    public void CheckIfAllDestoryed() {
        if (AllMembersDead() && (GameStateManager.currentGameStyle == GameStateManager.gameStyle.survive)) {
            LevelStateManagerScript.levelDone = true;
        }
    }
}
