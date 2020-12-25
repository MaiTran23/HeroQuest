using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    [SerializeField]
    private Text Scoretext;
    public static int diamondAmount;
    // Start is called before the first frame update
    void Start()
    {
        diamondAmount = 0;
        //Scoretext = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = diamondAmount.ToString();
        
    }
}
