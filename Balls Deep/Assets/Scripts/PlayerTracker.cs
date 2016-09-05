using UnityEngine;
using System.Collections;

public class PlayerTracker : MonoBehaviour {

    // public variables
    public GameObject playerPrefab;
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
	void Update () {
        if (CheckPlayerState() && go) {
            Debug.Log("Spawning Player");
            go = false;
            Invoke("SpawnPlayer", spawnDelay);
        }
	}


    void SpawnPlayer() {
        foreach (Transform child in transform) {
//            if(spawning && Random.Range(0,1f) < 0.5f) {
                Debug.Log("Should be spawning ONE player object.");
                GameObject player = Instantiate(playerPrefab, child.transform.position, Quaternion.identity) as GameObject;
                player.transform.parent = child.transform;
//            }
        }
        go = true;
    }

    bool CheckPlayerState() {
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount > 0) {
                Debug.Log("There's an exsisting child. Returning false.");
                return false;
            }
        }
        Debug.Log("No player exsists. Returning True.");
        return true;
    }
}
