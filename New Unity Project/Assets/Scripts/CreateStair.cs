using UnityEngine;
using System.Collections;

public class CreateStair : MonoBehaviour {
    private float time_;
    public GameObject stair_;
	// Use this for initialization
	void Start () {
        time_ = 0.0f;
        for (int i = 0; i < 20; i++)
        {
            Instantiate(stair_, new Vector3(0.0f, i * 1.0f, i * 1.0f), new Quaternion(0, 0, 0, 0));
        }
	}
	
	// Update is called once per frame
	void Update () {
        time_ += 1.0f * Time.deltaTime;
        if(time_%0.5f<0.02f){//割る時間＝生成する間隔
            Instantiate(stair_, new Vector3(0.0f, 9.0f, 9.0f), new Quaternion(0, 0, 0, 0));
        }
	}
}
