using UnityEngine;
using System.Collections;

public class PlayfieldScript : MonoBehaviour {

    public GameObject escapeDoor;
    public AudioClip openSound;
    public static int pickUpCountDown;

    
    private bool go;

    void Start() {
        pickUpCountDown = 3;
        go = true;
    }

	// Update is called once per frame
	void Update () {
        if (LevelStateManagerScript.levelEnd && escapeDoor) {
            OpenEscapeDoor();
        }

        if (GameStateManager.currentState == GameStateManager.playState.falling) {
            DestroyPlayfield();
        }

        if(pickUpCountDown <= 0 && go) {
            go = false;
            LevelStateManagerScript.levelEnd = true;
        }
    }

    void DestroyPlayfield() {
        Destroy(gameObject);
    }

    void OpenEscapeDoor() {
        AudioSource.PlayClipAtPoint(openSound, Camera.main.transform.position);
        Destroy(escapeDoor);
    }

}
