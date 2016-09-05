using UnityEngine;
using System.Collections;

public class TwoDShredder : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {
       if(collider.gameObject.tag == "Item" || collider.gameObject.tag == "Enemy") {
            Destroy(collider.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Item") {
            Destroy(collision.gameObject);
        }
    }
}
