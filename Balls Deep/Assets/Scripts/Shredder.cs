using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
