using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRespawnController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y < -10)
        {
            this.transform.position = new Vector3(4f, 6f, -14f);
        }
	}
}
