using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
    // public variables
    public float jumpHeight;
    public float moveSpeed;
    public AudioClip landNoise;

    // private variables
    private Rigidbody rb;
    private float jump;
    private bool inAir;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        jump = 0;
        inAir = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(GameStateManager.currentState == GameStateManager.playState.threeD) {
            rb.constraints = RigidbodyConstraints.None;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (LevelStateManagerScript.levelDone) {
                jump = 20f;
            } else if (Input.GetKeyDown(KeyCode.Space) && !inAir) {
                jump = jumpHeight;
                inAir = true;
            }

            Vector3 movement = new Vector3(moveHorizontal,0,moveVertical);

            rb.AddForce(movement * moveSpeed * Time.deltaTime);
        } else if (GameStateManager.currentState == GameStateManager.playState.twoD) {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            jump = 0;
            float moveSideWays = Input.GetAxis("Horizontal");

            if (LevelStateManagerScript.levelDone) {
                jump = 20f;
            } else if (Input.GetKeyDown(KeyCode.Space) && !inAir) {
                jump = jumpHeight;
                inAir = true;
            }

            if (moveSideWays < 0) {
                transform.Translate(Vector3.left * Time.deltaTime * 5f, Camera.main.transform);
            } else if (moveSideWays > 0) {
                transform.Translate(Vector3.right * Time.deltaTime * 5f, Camera.main.transform);
            }

            Vector3 movement = new Vector3(0,jump,0);

        } else if (GameStateManager.currentState == GameStateManager.playState.falling) {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = new Vector3(0, 2f, 0);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Playfield" && inAir) {
            AudioSource.PlayClipAtPoint(landNoise, Camera.main.transform.position);
            inAir = false;
            Debug.Log("Made contact with playing field. Can jump again.");
        }
    }

    bool Grounded() {
        return true;
    }

}
