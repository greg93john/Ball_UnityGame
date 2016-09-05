using UnityEngine;
using System.Collections;

public class FallSwitch : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            LevelStateManagerScript.levelDone = true;
        }
    }
}
