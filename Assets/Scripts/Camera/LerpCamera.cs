using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCamera : MonoBehaviour
{
    [SerializeField]
    private Transform trigger;
    [SerializeField]
    private Transform trigger2;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform Camera;
    private bool isLerp = false;
    private float speed = 1.0f;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (isLerp)
            StartCoroutine(PositionChanging());
        
    }

    //void PositionChanging()
    //{
    //    Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    //    Camera.GetComponent<CameraScripts>().enabled = false;
    //    Camera.transform.position = Vector3.Lerp(Camera.position, trigger.position, Time.deltaTime * speed);
    //}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            isLerp = true;
        }
    }

    public IEnumerator PositionChanging()
    {
        Camera.GetComponent<CameraScripts>().enabled = false;
        player.GetComponent<PlayerScript>().enabled = false;
        Camera.transform.position = Vector3.Lerp(Camera.position, trigger.position, Time.deltaTime * speed);
        yield return new WaitForSeconds(5.0f);
        isLerp = false;
        //Camera.transform.position = Vector3.Lerp(Camera.position, trigger2.position, Time.deltaTime * speed);
        //yield return new WaitForSeconds(5.0f);
        Camera.GetComponent<CameraScripts>().enabled = true;
        player.GetComponent<PlayerScript>().enabled = true;
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
