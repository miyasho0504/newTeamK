using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
    public float startTime_ = 5.0f;//何秒後にスタートさせるか
    public AudioClip bgm_;
    private AudioSource audioSource;
    private bool play_bgm_=false;

    public static float bpm_=147;

    public GameObject Count1_;
    public GameObject Count2_;
    public GameObject Count3_;
    public GameObject CountStart_;

    private bool panel_created_ = false;//パネルが生成されたか
    private bool panelS_deleted_ = false;//スタートパネルが削除されたか
    private bool panel1_deleted_ = false;//１パネルが削除されたか
    private bool panel2_deleted_ = false;//２パネルが削除されたか
    private bool panel3_deleted_ = false;//３パネルが削除されたか

    bool gameEnd_ = false;//ゲームクリアもしくはゲームオーバーになったか

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = bgm_;
	}
	
	// Update is called once per frame
	void Update () {
        if (play_bgm_ == false)
        {
            audioSource.Play();
            play_bgm_ = true;
        }
        if (AutoMove.automove_ == false)
        {
            startTime_ -= Time.deltaTime;
            //カウントダウン開始(パネル生成)
            if(startTime_<=3.0f&&panel_created_==false){
                Instantiate(CountStart_);
                Instantiate(Count1_);
                Instantiate(Count2_);
                Instantiate(Count3_);
                panel_created_ = true;
            }
            if(startTime_<=2.0f&&panel3_deleted_==false){
                GameObject panel3=GameObject.Find("CountPanel3(Clone)");
                GameObject.Destroy(panel3);
                panel3_deleted_ = true;
            }
            if (startTime_ <= 1.0f && panel2_deleted_ == false)
            {
                GameObject panel2 = GameObject.Find("CountPanel2(Clone)");
                GameObject.Destroy(panel2);
                panel2_deleted_ = true;
            }
            if (startTime_ <= 0.0f && panel1_deleted_ == false)
            {
                GameObject panel1 = GameObject.Find("CountPanel1(Clone)");
                GameObject.Destroy(panel1);
                panel1_deleted_ = true;
                AutoMove.automove_ = true;
                //audioSource.Play();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                bpm_ += 60;
            }
            //ゲームが終了したら
            if (gameEnd_ == true) { }   
        }
	}
}
