using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {
    public enum playState {twoD, threeD, falling, topDown};
    public enum gameStyle { survive, collect};
    
    // public variables
    public static playState currentState;
    public static gameStyle currentGameStyle;
    public static bool playing;
    public Transform topDown;
    public Transform threeD;

    // private variables
    private bool done;
    private PlayfieldTracker fieldSpawner;

    void Awake() {
        fieldSpawner = GameObject.Find("PlayFieldSpawner").GetComponent<PlayfieldTracker>();
        playing = false;
    }

	// Use this for initialization
	void Start () {
        currentState = playState.threeD;
	}
	
	// Update is called once per frame
	void Update () {

        switch (currentState) {
            case playState.twoD: {
                    Camera.main.orthographic = true;
                }
                break;

            case playState.threeD: {
                    Camera.main.transform.position = threeD.position;
                    Camera.main.transform.rotation = threeD.rotation;
                    Camera.main.orthographic = false;
                }
                break;

            case playState.topDown: {
                    Camera.main.transform.position = topDown.position;
                    Camera.main.transform.rotation = topDown.rotation;
                    Camera.main.orthographic = true;
                }
                break;

            case playState.falling: {
                    if(!done) {
                        done = true;
                        Camera.main.transform.position = threeD.position;
                        Camera.main.transform.rotation = threeD.rotation;
                        Camera.main.orthographic = true;
                    }
                }
                break;

            default:
                break;
        }
	}

    public void ChangeGameState() {
        LevelStateManagerScript.levelDone = false;
        if (Random.value <= 0.5f) {
            currentState = playState.twoD;
            Debug.Log("Game state is in 2D");
        } else {
            currentState = playState.threeD;
            Debug.Log("Game state is in 3D");
        }
        LevelStateManagerScript.levelEnd = false;
        fieldSpawner.SpawnNewPlayfield();
    }
}
