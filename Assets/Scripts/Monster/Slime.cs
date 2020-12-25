using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private Rigidbody2D myBody;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "EndPos") {

            Vector3 temp = transform.localScale;
            if (temp.x ==5f)
            {
                temp.x = -5f;
            } else
            {
                temp.x = 5f;
            }

            transform.localScale = temp;

        }

        //if (target.gameObject.tag == "Player")
        //{
        //    Destroy(target.gameObject);
        //}
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        
    }

    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
}
