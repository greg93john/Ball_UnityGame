using UnityEngine;
using System.Collections;

public class EnemySpawnPosition : MonoBehaviour {

    public void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
