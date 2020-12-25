using UnityEngine;
using System.Collections;

public class SpiderBullet : MonoBehaviour {

	private Animator anim;

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player") {
			//GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
			Destroy(target.gameObject);
			//anim.SetBool("Explosion", true);
			Destroy(gameObject);
		}

		if (target.gameObject.tag == "Ground" || target.gameObject.layer == 12) {
			//anim.SetBool("Explosion", true);
			Destroy(gameObject);
		}
	}

}
