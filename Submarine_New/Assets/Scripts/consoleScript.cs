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
        Debug.Log(consoleString);
    }


    public static void resetInput()
    {
        consoleString = "";
    }


    void OnTriggerStay2D(Collider2D col) 
    {
        
        if (col.CompareTag("Player"))
        {

            for (int i = 'a'; i < 'z'; i++)
         {
                string casted = (char)i + "";
                if (Input.GetKeyDown(casted) && casted != lastKey)
                {
                    consoleString += casted;
                   lastKey = casted;
                
                }

            }
            }
        }

    void OnTriggerExit (Collider col)
    {
        resetInput();
    }
    }

