using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarScript : MonoBehaviour
{

    public static int totalHealth = 3;
    public const int threshold = 0;

    public static int getHealth()
    {
        return totalHealth;
    }

    public static void decrementHealth()
    {
        totalHealth--;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    void checkTaskFailed()
    {

        if (getHealth() <= threshold)
        {
            gameObject.SetActive(!gameObject.activeSelf);
            gameOver();
        }
    }




    void gameOver()
    {


        // Do Game Over Stuff

    }






    // Update is called once per frame
    void Update()
    {
        decrementHealth();
        Debug.Log(getHealth());
        checkTaskFailed();


    }
}
