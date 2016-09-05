using UnityEngine;
using System.Collections;

public class LevelStateManagerScript : MonoBehaviour {

    // public variables
    public static bool levelDone;
    public static bool levelEnd;
    public static int goalCollectables;
    public float changeDelay;

    //private variables
    private GameObject gameState;

    void Awake() {
        levelEnd = false;
        levelDone = false;
    }

    void Start () {
        gameState = GameObject.Find("GameStateManager");
	}
	
	void Update () {
        if (levelDone) {
            Invoke("StartFalling",changeDelay);
            levelDone = false;
        }

        switch (GameStateManager.currentGameStyle) {
            case GameStateManager.gameStyle.collect: {
                    
                }
                break;
            case GameStateManager.gameStyle.survive: { }
                break;
            default: { Debug.Log("There's no current game style set for 'gameStyle' variable in the GameStateManager script."); }
                break;
        }
    }

    void StartFalling() {
        GameStateManager.currentState = GameStateManager.playState.falling;
        Invoke("EndFalling", changeDelay);
    }

    void EndFalling() {
        GameStateManager game = gameState.GetComponent<GameStateManager>();
        game.ChangeGameState();
    }
}
