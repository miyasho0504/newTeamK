using UnityEngine;
using System.Collections;

public class Stair : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0.0f,-2.0f,-2.0f)*Time.deltaTime;
        Vector3 pos = transform.position;
        if(pos.y<-2.0f){
            Destroy(gameObject);
        }
	}
}
