using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    private float agroRange;
    [SerializeField]
    private float moveSpeed;
    private Animator anim;

    Rigidbody2D rb2d;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < agroRange)
        {
            ChasePlayer();
            anim.SetBool("Chase", true);
        }

        else
        {
            StopChasingPlayer();
            anim.SetBool("Chase", false);
        }

        void ChasePlayer()
        {

            if(transform.position.x < player.position.x)
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(5, 5);

            }

            else
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(-5, 5);
            }

            
        }

        void StopChasingPlayer()
        {

            rb2d.velocity = new Vector2(0,0);
            

        }

       
        
    }

    //private void OnCollisionEnter2D(Collision2D target)
    //{

    //    if (target.gameObject.tag == "Player")
    //    {
    //        Destroy(target.gameObject);
    //    }

    //}
}
