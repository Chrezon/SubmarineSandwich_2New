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

            if (Input.GetKeyDown(KeyCode.Return))
            {
                enter = true;

                resetInput();

            }
            
            


                for (int i = 'a'; i <= 'z'; i++)
                {
                    string casted = (char)i + "";
                Debug.Log(consoleString);
                    

                    if (Input.GetKeyDown((char)i + "") && casted != lastKey && !enter)
                    {
                        consoleString += (char)i + "";
                        lastKey = (char)i + "";
                        break;

                    }

                }
            
            }
        }


    }

