using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

    public enum itemType { collectable };

    // public variables
    public itemType currentItem;
    public AudioClip collectNoise;

    // private variables
    private bool go = true;

    // Update is called once per frame
    void Update () {
        if(currentItem == itemType.collectable) {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        if(GameStateManager.currentState == GameStateManager.playState.twoD) {
            transform.Translate(Vector3.back * Time.deltaTime * 2f, Space.World);
            if (go) { 
                Invoke("Disappear", 3f);
                go = false;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Item has collided with something.");
        if(other.gameObject.tag == "Player") {
            if (currentItem == itemType.collectable) {
                if(GameStateManager.currentState == GameStateManager.playState.twoD) {
                    PlayfieldScript.pickUpCountDown--;
                }
                AudioSource.PlayClipAtPoint(collectNoise,Camera.main.transform.position);
                Disappear();
            }
        } 
    }

    void Disappear() {
        Destroy(gameObject);
    }
}
