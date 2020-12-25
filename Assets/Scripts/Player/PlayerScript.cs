using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10;
    [SerializeField]
    private float jumpForce = 700f;
    float _jumpForce;
    [SerializeField]
    private float maxVelocity = 4f;
    private bool grounded;
    private Rigidbody2D myBody;
    private Animator anim;


    private bool moveLeft, moveRight;




    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(() => Jump());
    }


    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
    }

    public void SetMoveRight(bool moveRight)
    {
        this.moveRight = moveRight;
    }

    public void StopMoving()
    {
        this.moveLeft = false;
        this.moveRight = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkJoyStick();

     

    }

    void PlayerWalkJoyStick()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (moveRight)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = 5f;
            transform.localScale = scale;

            anim.SetBool("Run", true);
        }

            else if (moveLeft)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.localScale;
            scale.x = -5f;
            transform.localScale = scale;

            anim.SetBool("Run", true);

        } else
        {
            anim.SetBool("Run", false);
        }

        var velo = myBody.velocity;
        //myBody.AddForce(new Vector2(forceX, 0));
        myBody.velocity = new Vector2(forceX, velo.y);
        //transform.Translate(moveForce * Time.deltaTime * new Vector2(forceX, 0));


    }



    void Jump()
    {
        if (IsGrounded())
        {
            _jumpForce = jumpForce;
            myBody.velocity = new Vector2(0, jumpForce);
            FindObjectOfType<AudioController>().Play("Jump");

        }
    }

    public LayerMask groundLayer;

    bool IsGrounded()
    {

        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1f, groundLayer.value))
        {
            Debug.DrawRay((new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z)), Vector3.down, Color.green, 5);
            
            return true;
            
        }
        else
        {
            
            return false;
        }
    }

}
