using UnityEngine;
using System.Collections;

public class WallPosition : MonoBehaviour
{

    public void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    public void ClearEmptyWalls() {
        foreach (Transform child in transform) {
            if (child.gameObject.tag != "Wall") {
                Destroy(child.gameObject);
            }
        }
    }
    
}