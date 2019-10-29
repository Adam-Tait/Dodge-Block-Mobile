using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public float difficulty = 20;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / difficulty;
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
	}
}
