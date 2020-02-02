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
        
    }



    public static void resetInput()
    {
        consoleString = "";
    }

    public static string getLastString ()
    {
        string output = consoleScript.consoleString;
        resetInput();
        return output;
    }


    void OnTriggerStay2D(Collider2D col) 
    {
        bool enter = false;
        string current = "";
        
        if (col.CompareTag("Player"))
        {


            for (int i = 13; i < 'z'; i++)
         {
                string casted = (char)i + "";
                Debug.Log("f" + casted + "f " + consoleString);
                if (i < 97 && i > 13)
                {
                    continue;
                } else if (Input.GetKeyDown(KeyCode.Return))
                {
                    enter = true;
                    
                    resetInput();
                    
                } else if (Input.GetKeyDown(casted) && casted != lastKey && !enter)
                {
                   consoleString += casted;
                   lastKey = casted;
                
                }

            }
            }
        }



    void OnTriggerExit2D (Collider2D obj)
    {
        
        
    }
    }

