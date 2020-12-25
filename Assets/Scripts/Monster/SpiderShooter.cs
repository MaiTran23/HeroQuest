using UnityEngine;
using System.Collections;

public class SpiderShooter : MonoBehaviour {

	[SerializeField]
	private GameObject bullet;

	// Use this for initialization
	void Start () {
		StartCoroutine (Attack ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Attack(){
		yield return new WaitForSeconds (Random.Range (2, 6));
		Instantiate (bullet, transform.position, Quaternion.identity);
		StartCoroutine (Attack ());
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			//GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
			Destroy(target.gameObject);
		}
	}
}
