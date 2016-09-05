using UnityEngine;
using System.Collections;

public class PlayerSpawnPosition : MonoBehaviour {

    public void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

}
