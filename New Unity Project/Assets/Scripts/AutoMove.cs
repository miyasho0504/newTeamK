using UnityEngine;
using System.Collections;

//自動で移動する挙動の制御(プレイヤーと階段)
public class AutoMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0.0f, -2.0f, -2.0f) * Time.deltaTime;
	}
}
