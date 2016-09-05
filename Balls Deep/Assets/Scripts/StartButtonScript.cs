using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GoAway() {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collison) {
        if(collison.gameObject.tag == "Player") {
            GameStateManager.playing = true;
            GoAway();
            LevelStateManagerScript.levelDone = true;
            Debug.Log("Player GameObject Touched button");
        }
    }
}
