using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float time_;
    public float waruTime_=0.5f;

    private bool isJump_=false;//ジャンプ中か

	// Use this for initialization
	void Start () {
        time_ = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {        
        Vector3 pos = transform.position;
        time_ += 1.0f * Time.deltaTime;
        //ジャンプ
        /*if (time_ % waruTime_ < 0.03f &&isJump_==false)
        {
            isJump_ = true;
            pos.y += 1.2f;
            transform.position = pos;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }*/
        
        //Spaceキーで前に進む
        if (Input.GetKeyDown(KeyCode.Space)){
            pos.z += 1.0f;
            pos.y += 1.3f;
            transform.position = new Vector3(pos.x,pos.y,pos.z);
        }
        //Enterキーでリセット
        if (Input.GetKeyDown(KeyCode.Return))
        {
            transform.position = new Vector3(0.0f, 1.0f, -1.0f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
	}
    void OnCollisionEnter()
    {
        isJump_ = false;
    }
}
