using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBullet : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * thrust;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            //GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
            Destroy(target.gameObject);
            Destroy(gameObject);
        }

        if (target.gameObject.tag == "Ground" || target.gameObject.layer == 12)
        {
            Destroy(gameObject);
        }

        if (target.gameObject.tag == "Object")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}
