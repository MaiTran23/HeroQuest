using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
	// Start is called before the first frame update
	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			//GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
			Destroy(target.gameObject);
			//Destroy(gameObject);
		}

		//if (target.gameObject.tag == "Ground")
		//{
		//	Destroy(gameObject);
		//}
	}


}
