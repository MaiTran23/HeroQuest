using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoor : MonoBehaviour
{
    public static BlockDoor instance;
    private Animator anim;
    private BoxCollider2D box;

    [HideInInspector]
    public int TriggerDoor;

    private void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    IEnumerator OpenDoor()
    {
        anim.Play("Block");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }

    public void DecrementTrigger()
    {
        TriggerDoor--;
        if (TriggerDoor == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
