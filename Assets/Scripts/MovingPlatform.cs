using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pos1 = new Vector3(0, 0, 0);
    public Vector3 pos2 = new Vector3(0, 0, 0);
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player" || target.gameObject.tag == "Ground")
        {
            target.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {

        if (target.gameObject.tag == "Player" || target.gameObject.tag == "Ground")
        {
            target.collider.transform.SetParent(null);
        }

    }
}
