using UnityEngine;
using System.Collections;

public class GameTitleTracker : MonoBehaviour {

    // public variables
    public GameObject gameTitle;

    // private variables
    private bool makeTitle;

	void Update () {
        if (!GameStateManager.playing && makeTitle) {
            DisplayGameTitle();
        } else if(!GameStateManager.playing && transform.childCount == 0) {
            makeTitle = true;
        }
	}

    void DisplayGameTitle() {
        GameObject titleText = Instantiate(gameTitle,transform.position,Quaternion.identity) as GameObject;
        titleText.transform.parent = transform;
        makeTitle = false;
    }
}
