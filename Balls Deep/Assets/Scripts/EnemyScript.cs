using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    //public variables
    public float health = 100f;
    public float projectileSpeed;
    public float strafeSpeed = 1f;
    public float shotsPerSecond;
    public AudioClip deathSound;
    public GameObject enemyProjectile;
    public Transform barrelEnd;


    //private variables
    private bool movingUp;
    private float probability;

    // Use this for initialization
    void Start () {
        float camDistance = transform.position.y - Camera.main.transform.position.y;

        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,camDistance,0));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,camDistance,0));
        Vector3 upMost = Camera.main.ViewportToWorldPoint(new Vector3(0, camDistance, 1));
        Vector3 downMost = Camera.main.ViewportToWorldPoint(new Vector3(0, camDistance, 0));

        if(Random.value >= 0.5f) { movingUp = true; }
        else { movingUp = false; }
    }

    // Update is called once per frame
    void Update () {

        //movement code

        if (movingUp) {
            transform.Translate(Vector3.up * Time.deltaTime * strafeSpeed, Camera.main.transform);
        } else {
            transform.Translate(Vector3.down * Time.deltaTime * strafeSpeed, Camera.main.transform);
        }

        probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability) {
            FireMethod();
        }

        if(health <= 0f) {
            Die();
        }
    }

    void OnTriggerEnter(Collider collision) {

        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if(missile) {
            health -= missile.GetDamage();
            missile.Hit();
        }

        else {
            Debug.Log("Enemy Collided with Play Area");
            DirectionChange();
        }
    }

    void DirectionChange() {
        movingUp = !movingUp;
    }

    void Die() {
      //AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
    }

    void FireProjectile() {
        
    }

    // creates an enemy laser and fires it in the specified direction
    void FireMethod() {
        GameObject beam = Instantiate(enemyProjectile, barrelEnd.position, barrelEnd.rotation) as GameObject;
        beam.GetComponent<Rigidbody>().velocity = new Vector3(-projectileSpeed, 0, 0);
        //AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
}
