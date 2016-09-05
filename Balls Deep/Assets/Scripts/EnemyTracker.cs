using UnityEngine;
using System.Collections;

public class EnemyTracker : MonoBehaviour {

    // public variables
    public GameObject enemyPrefab;
    public float width;
    public float height;
    public float spawnDelay;

    // private vaiables
    private bool go;

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, 0, height));
    }


    void Start() {
        go = true;
    }
    // Update is called once per frame
    void Update() {
        if (CheckEnemyState() && go) {
            go = false;
            Invoke("SpawnEnemy", spawnDelay);
        }
    }


    void SpawnEnemy() {
        bool spawning = true;
        foreach (Transform child in transform) {
            if (spawning && Random.Range(0, 1f) < 0.5f) {
                Debug.Log("Should be spawning ONE enemy object.");
                spawning = false;
                GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child.transform;
            }
        }
        go = true;
    }


    bool CheckEnemyState() {
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount > 0) {
                Debug.Log("There's an exsisting Enemy. Returning false.");
                return false;
            }
        }
        Debug.Log("No Enemy exsists. Returning True.");
        return true;
    }
}

