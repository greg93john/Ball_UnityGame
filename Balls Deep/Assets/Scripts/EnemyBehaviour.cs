using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    // public variables
    public float moveSpeed;
    public AudioClip killSound;

    // private variables
    private GameObject player;
    private Vector3 movement;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void Update() {
        if (GameStateManager.currentState == GameStateManager.playState.twoD) {
            rb.AddForce(Vector3.back * moveSpeed * Time.deltaTime);
        } else { 
          if (player) {
            movement = new Vector3();
            MoveToPlayer();
         } else { FindPlayerAgain(); }

         if (LevelStateManagerScript.levelEnd) {
            Destroy(gameObject);
         }
        }
    }

    void FindPlayerAgain() {
        player = GameObject.Find("Player(Clone)");
    }

    void MoveToPlayer() {
        if (transform.position.x < player.transform.position.x) {
            movement.x = 1f;
        } else if(transform.position.x > player.transform.position.x) {
            movement.x = -1f;
        }

        if (transform.position.z < player.transform.position.z) {
            movement.z = 1f;
        } else if (transform.position.z > player.transform.position.z) {
            movement.z = -1f;
        }

        rb.AddForce(movement * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject == player) {
            Debug.Log("Player Should be killed");
            AudioSource.PlayClipAtPoint(killSound, Camera.main.transform.position);
            Destroy(collision.gameObject);
        } else { Debug.Log("Touched something other than player."); }
    }
}
