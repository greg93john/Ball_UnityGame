using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

    public float wallHealth;

    void Update() {
        if(wallHealth <= 0) {
            DestroyThis();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Projectile") {
            Debug.Log("Wall hit by projectile! Taking damage!");
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            wallHealth -= projectile.GetDamage();
            projectile.Hit();
        }
    }

    public void DestroyThis() {
        Debug.Log("Destroying Wall GameObject");
        Destroy(this.gameObject);
    }
}