using UnityEngine;
using System.Collections;

public class Stair : MonoBehaviour {
    public bool create_clone_;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if(pos.y<-2.0f){
            Destroy(gameObject);
        }
	}
}
