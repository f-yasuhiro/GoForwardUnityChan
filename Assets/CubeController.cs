using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	// キューブの移動速度
	private float speed = -0.2f;
	// 消滅位置
	private float deadLine = -10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);
		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		// キューブが地面に接触する時とキューブ同士が積み重なるときに効果音をつける
		if (other.gameObject.name == "ground" || (other.gameObject.name == "CubePrefab(Clone)" && this.transform.position.y > other.gameObject.transform.position.y)) {
			GetComponent<AudioSource> ().Play ();
		}
	}
}
