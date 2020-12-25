using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerScript player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left")
        {
            player.SetMoveLeft(true);
            //Debug.Log("Left");
        }
        else
        {
            player.SetMoveRight(true);
            //Debug.Log("Right");
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        player.StopMoving();

    }
}
