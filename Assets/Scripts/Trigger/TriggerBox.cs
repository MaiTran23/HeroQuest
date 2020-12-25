using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    [SerializeField]
    private Transform trigger3;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform Camera;
    private float speed = 1.0f;
    private bool isStep = false;
    // Start is called before the first frame update
    void Start()
    {

        if(BlockDoor.instance != null)
        {
            BlockDoor.instance.TriggerDoor++;

        }
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            if(BlockDoor.instance != null)
            {
                BlockDoor.instance.DecrementTrigger();
            }

            isStep = true;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStep)
            StartCoroutine(PositionChanging());

    }

    public IEnumerator PositionChanging()
    {
        Camera.GetComponent<CameraScripts>().enabled = false;
        player.GetComponent<PlayerScript>().enabled = false;
        Camera.transform.position = Vector3.Lerp(Camera.position, trigger3.position, Time.deltaTime * speed);
        yield return new WaitForSeconds(5.0f);
        isStep = false;
        Camera.GetComponent<CameraScripts>().enabled = true;
        player.GetComponent<PlayerScript>().enabled = true;
        yield return new WaitForSeconds(1.0f);
        //Destroy(gameObject);
    }
}
