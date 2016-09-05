using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
            Invoke("DestroySelf", 3f); 
	}

    void DestroySelf() {
        Destroy(gameObject);
    }
}
