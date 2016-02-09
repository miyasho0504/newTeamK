using UnityEngine;
using System.Collections;

//自動で移動する挙動の制御(プレイヤーと階段)
public class AutoMove : MonoBehaviour {
    public float bpm_ = 60;
    public float setTime_;//自動移動の1回目が起こるまでの時間
    private float intervalTime_;
    public GameObject stair_;
    public float moveYZ_=0.2f;//どれだけ大きく移動させるか
    private bool automove1_=false;//自動移動の1回目(大きめの移動)がなされたか 
	
    // Use this for initialization
	void Start () {
        setTime_ = 60.0f / bpm_;//BPMから次のジャンプまでの時間を計算する
        intervalTime_ = setTime_;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos;
        Vector3 scale;
        //だいたい(setTime_)秒ごとに処理を行う
        intervalTime_ -= Time.deltaTime;
        if (intervalTime_ <= 0.1)//0.1秒前から判定を入れる
        {
            pos = transform.position;               //大きく移動させる前のポジションを記録
            scale = stair_.transform.localScale;    //階段の大きさ(何倍か)を記録
            //まずは移動させたい距離より大きめに移動させて
            if(automove1_==false){
                pos.y -= 1.0f*scale.y+moveYZ_;
                pos.z -= 1.0f * scale.z + moveYZ_;
                transform.position = pos;
                automove1_ = true;
            }
            //0.1秒後に元に戻す(ただし自動移動の1回目が行われてから)
            if (intervalTime_ <= 0.0&&automove1_==true)
            {
                intervalTime_ = setTime_;
                pos.y += moveYZ_;
                pos.z += moveYZ_;
                transform.position = pos;
                automove1_ = false;
            }
        }
	}
}
