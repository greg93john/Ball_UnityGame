using UnityEngine;
using System.Collections;

public class GameTitleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameStateManager.playing) {
            Destroy(gameObject);
        }
	}
}
