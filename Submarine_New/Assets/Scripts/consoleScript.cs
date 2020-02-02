using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleScript : MonoBehaviour
{
    public static string consoleString = "";
    public static string lastKey = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D();
    }


    void resetInput()
    {
        consoleString = "";
    }


    void OnTriggerEnter2D() //Collider2D col
    {
        bool antiSpam = false;


        for (int i = 'a'; i < 'z'; i++)
        {
            string casted = (char)i + "";
            if (Input.GetKeyDown(casted))
            {
                consoleString += casted;
                lastKey = casted;
                antiSpam = true;
            }

        }
    }








    Debug.Log(consoleString);
        //if (col.CompareTag("Player"))
       // {
       //
       //     Debug.Log("player entered this area");
       // }
    }
}
