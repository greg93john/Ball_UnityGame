using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

    public void OnDrawGizmos() {

        switch (gameObject.tag) {
            case "Enemy": {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(transform.position, 0.5f);
                }
                break;

            case "Item": {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawWireCube(transform.position, new Vector3(0.5f,0.5f,0.5f));
                }
                break;

            case "Player": {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
                }
                break;

            case "Random": {
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireSphere(transform.position, 0.5f);
                }
                break;

            default: Debug.Log("GameObject tag not specified for Gizmos");
                break;
        }
    }
}
