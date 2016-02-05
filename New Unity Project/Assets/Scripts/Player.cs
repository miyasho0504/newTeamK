using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float time_;
    public float waruTime_=0.5f;
	// Use this for initialization
	void Start () {
        time_ = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        time_ += 1.0f * Time.deltaTime;
        //ジャンプ
        if (time_ % waruTime_ < 0.1f)
        {
            transform.position = new Vector3(0.0f,1.0f,-1.0f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
	}
}
