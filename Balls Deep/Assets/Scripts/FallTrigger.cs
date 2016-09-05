using UnityEngine;
using System.Collections;

public class FallTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collison) {
        if(collison.gameObject.tag == "Player") {
            LevelStateManagerScript.levelDone = true;
        }
    }
}
