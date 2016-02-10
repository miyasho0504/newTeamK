using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float time_;
    //public float waruTime_=0.5f;
    public static bool ablejump_=true;//ジャンプすることは可能か
    public static bool sudenijump_ = false;//既に1回ジャンプしたか
    public static bool tyakuti_ = false;//着地したか

	// Use this for initialization
	void Start () {
        time_ = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {        
        Vector3 pos = transform.position;
        
        //ジャンプ
        /*if (time_ % waruTime_ < 0.03f &&isJump_==false)
        {
            isJump_ = true;
            pos.y += 1.2f;
            transform.position = pos;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }*/
        
        //Spaceキーで前に進む
        /*if (Input.GetKeyDown(KeyCode.Space)){
            pos.z += 1.0f;
            pos.y += 1.1f;
            transform.position = new Vector3(pos.x,pos.y,pos.z);
        }*/
        //キーが何秒押されているかを判定する
        if (Input.GetKey(KeyCode.Space))
        {
            time_ += Time.deltaTime;
        }
        //キーが離される＆ジャンプ中でない
        if(Input.GetKeyUp(KeyCode.Space)){
            sudenijump_ = true;
            float setTime_ = (60.0f / MainGame.bpm_)-0.1f;
            //1回のジャンプ以上に溜めていたら
            if (ablejump_ == true)
            {
                if (time_ < setTime_)
                {
                    tyakuti_ = false;
                    pos.z += 1.0f;
                    pos.y += 1.05f;
                    transform.position = new Vector3(pos.x, pos.y, pos.z);
                }
                else
                {
                    tyakuti_ = false;
                    pos.z += 2.0f;
                    pos.y += 2.0f;
                    transform.position = new Vector3(pos.x, pos.y, pos.z);
                }
            }
            time_=0.0f;
        }

        //Enterキーでリセット
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            transform.position = new Vector3(0.0f, 1.0f, -1.0f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }*/
	}
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OK");
        if(col.gameObject.tag=="stair"){
            tyakuti_ = true;
        }
		if (col.gameObject.tag == "Finish") {
			Destroy (this.gameObject);
		}
    }
}
