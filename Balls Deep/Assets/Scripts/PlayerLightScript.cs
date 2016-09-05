using UnityEngine;
using System.Collections;

public class PlayerLightScript : MonoBehaviour {
    // public variables

    // private varibles
    private Vector3 playerToLight;
    private GameObject playerObject;

    // Use this for initialization
    void Start () {
        playerObject = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObject) {
            transform.position = playerObject.transform.position + playerToLight;
        } else { Debug.Log("Looking for player"); FindPlayer(); }
    }

    void FindPlayer() {
        playerObject = GameObject.Find("Player(Clone)");
        if (playerObject) {
            transform.position = playerObject.transform.position + new Vector3(0,4f,-4f);
            playerToLight = transform.position - playerObject.transform.position;
        }
    }
}
