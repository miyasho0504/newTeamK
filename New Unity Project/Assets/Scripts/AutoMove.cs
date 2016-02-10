using UnityEngine;
using System.Collections;

//自動で移動する挙動の制御(プレイヤーと階段)
public class AutoMove : MonoBehaviour {
    public float setTime_;//自動移動の1回目が起こるまでの時間
    private float intervalTime_;
    public GameObject stair_;
    public static float moveYZ_=0.01f;//どれだけ大きく移動させるか
    private bool automove1_=false;//自動移動の1回目(大きめの移動)がなされたか
    public static bool automove_ = false;//自動移動を行うか否か

    private bool create_stair_=false;//自分のクローンを作成したかどうか(階段の自動生成のため)※一度だけ使用する 
    
    // Use this for initialization
	void Start () {
        setTime_ = 60.0f / MainGame.bpm_;//MainGameスクリプトにあるstatic変数BPMを使って次のジャンプまでの時間を計算する
        intervalTime_ = setTime_;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos;
        Vector3 scale;
        //だいたい(setTime_)秒ごとに処理を行う
        if (automove_ == true)
        {
            intervalTime_ -= Time.deltaTime;
            //プレイヤーがジャンプ可能であるか
            if (Player.sudenijump_ == false&&Player.tyakuti_==true)
            {
                if (gameObject.tag == "Player")
                {
                    Player.ablejump_ = true;
                    Debug.Log("ablejump=true");
                }
            }
            else { 
                Player.ablejump_ = false;
                Debug.Log("ablejump=false");
            }
            //自動移動
            if (intervalTime_ <= 0.1)//0.1秒前から判定を入れる
            {
                pos = transform.position;               //大きく移動させる前のポジションを記録
                scale = stair_.transform.localScale;    //階段の大きさ(何倍か)を記録
                //まずは移動させたい距離より大きめに移動させて
                if (automove1_ == false)
                {
                    pos.y -=0.05f + moveYZ_;
                    pos.z -=0.05f + moveYZ_;
                    transform.position = pos;
                    automove1_ = true;
                }
                //0.1秒後に元に戻す(ただし自動移動の1回目が行われてから)
                if (intervalTime_ <= 0.0 && automove1_ == true)
                {
                    setTime_ = 60.0f / MainGame.bpm_;
                    intervalTime_ = setTime_;
                    pos.y += moveYZ_;
                    pos.z += moveYZ_;
                    transform.position = pos;
                    automove1_ = false;
                    if(gameObject.tag=="Player"){
                        Player.sudenijump_ = false;
                        Debug.Log("sudenijump=false");
                    }
                    if (pos.y <= -0.05 && gameObject.tag == "stair" && create_stair_ == false)
                    {
                        //一度RendererとColliderを有効化する(これをしないと自身が複製される仕様上穴からは穴しか生成されず死ぬ)
                        GameObject ownChild = gameObject.transform.FindChild("stair_body").gameObject;
                        Renderer ownRend_ = ownChild.GetComponent<Renderer>();
                        Collider ownCol_ = ownChild.GetComponent<Collider>();
                        ownRend_.enabled = true;
                        ownCol_.enabled = true;
                        //Debug.Log("A");
                        GameObject st = Instantiate(stair_, new Vector3(0.0f, 0.45f, 0.45f), new Quaternion(0, 0, 0, 0)) as GameObject;
                        Stair.holeNumCount_++; Debug.Log(Stair.holeNumCount_);
                        if (Stair.holeNumCount_ % 7 == 0)
                        {
                            GameObject stchild = st.transform.FindChild("stair_body").gameObject;
                            Renderer rend_ = stchild.GetComponent<Renderer>();
                            Collider col_ = stchild.GetComponent<Collider>();
                            rend_.enabled = false;
                            col_.enabled = false;
                            //Stair_body s = stchild.GetComponent<Stair_body>();
                            //s.delRendRig();
                        }

                        create_stair_ = true;
                    }
                }
            }
        }
        else
        {
            
        }
	}
}
