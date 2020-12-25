using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.layer == 12)
        {
            //Destroy(target.gameObject);
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Diamond")
        {
            ScoreTextScript.diamondAmount++;
            Debug.Log("Diamond");
            Debug.Log("Other Collider" + target.name);
            FindObjectOfType<AudioController>().Play("Item");
         

        }

        if (target.gameObject.tag == "SavePoint")
        {
            FindObjectOfType<AudioController>().Play("CheckPoint");
        }

    }
}
