using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    //public variables
    public float moveSpeed;
    public float firingRate = 0.2f;
    public float projectileSpeed = 5f;
    public float health;
    public GameObject playerProjectile;
    public Transform barrelEnd;

    //private variables

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed, 0), Camera.main.transform);

        if (Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("FireMethod", 0.000001f, firingRate);
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("FireMethod");
        }


        if(health <= 0f) {
            Die();
        }
    }

    void OnCollisionEnter(Collision collision) {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile) {
            health -= missile.GetDamage();
            missile.Hit();
        }
    }

    // creates a player laser when pressing the spacebar, and pushes it's Rigidbody towards the top of the screen.
    void FireMethod() {
        GameObject beam = Instantiate(playerProjectile, barrelEnd.position, barrelEnd.rotation) as GameObject;
        beam.GetComponent<Rigidbody>().velocity = new Vector3(projectileSpeed, 0, 0);
        //AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void Die() {
        //AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
    }
    
}
