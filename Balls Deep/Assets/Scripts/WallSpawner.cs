using UnityEngine;
using System.Collections;

public class WallSpawner : MonoBehaviour {
    // public variables
    public GameObject wallPrefab;
    public GameObject emptySpace;
    public float width;
    public float height;
    public float spawnDelay = 0.5f;

    //private variabes
    private float xMin;
    private float xMax;

    // Use this for initialization
    void Start() {
        float playEdgePadding = width * 0.5f;
        float camDistance = transform.position.z - Camera.main.transform.position.z;

        //Declaires vectors that get the left-most and right-most values of the x position from the perspective of the camera.
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, camDistance));

        xMin = leftMost.x + playEdgePadding;
        xMax = rightMost.x - playEdgePadding;

        SpawnWalls();
    }

    // Update is called once per frame
    void Update() {
        if (AllMembersDead()) {
            Debug.Log("All walls are gone, Respawning!");
            SpawnWalls();
        }
    }




    // Creates a Gizmo on the unity editor window of a cube.
    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, 0, height));
    }

    //function spawns individual enemies one by one. (This Method is not used, and is held for reference).
    void SpawnTilFull() {

        Transform freePosition = NextFreePosition();

        if (freePosition) {
            if (Random.Range(0, 1f) < 0.7f) {
                Debug.Log("WallPrefab is spawning");
                GameObject wall = Instantiate(wallPrefab, freePosition.position, Quaternion.identity) as GameObject;
                wall.transform.parent = freePosition;
            } else {
                Debug.Log("The wallPrefab should not spawn");
                GameObject wall = Instantiate(emptySpace, freePosition.position, Quaternion.identity) as GameObject;
                wall.transform.parent = freePosition;
                WallPosition position = freePosition.GetComponent<WallPosition>();
                position.ClearEmptyWalls();
            }
        }


        if (NextFreePosition()) {
            Invoke("SpawnTilFull", spawnDelay);
        }
    }




    //function spawns all enemies at once.
    void SpawnWalls() {
        // runs the following code block for each child tranform of this GameObject (EnemyFormation).
        foreach (Transform child in transform) {
            if (Random.Range(0, 1f) < 0.7f) {
                Debug.Log("WallPrefab is spawning");
                GameObject wall = Instantiate(wallPrefab, child.transform.position, Quaternion.identity) as GameObject;
                wall.transform.parent = child.transform;
            } else {
                Debug.Log("The wallPrefab should not spawn");
                GameObject wall = Instantiate(emptySpace, child.transform.position, Quaternion.identity) as GameObject;
                wall.transform.parent = child.transform;
            }
        }
    }

    //Function returns the transform of the next empty child object of This gameObject's transform, or it returns 'null'.
    Transform NextFreePosition() {
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount == 0) {
                return childPositionGameObject;
            }
        }
        return null;
    }



    // this method checks for child object transforms that are attached to the transform of this object.
    bool AllMembersDead() {
        //foreach loop checks each child gameObject, to see if there is a child gameObject within it. Method returns false as soon as it finds a child gameObject with a child gameObject within it. Otherwise returns true.
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount > 0) {
                return false;
            }
        }
        return true;
    }
}
