using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarScript3 : MonoBehaviour
{


    public const int threshold = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    void checkTaskFailed()
    {

        if (LifeBarScript.getHealth() <= threshold)
        {
            gameObject.SetActive(!gameObject.activeSelf);

        }
    }








    // Update is called once per frame
    void Update()
    {

        checkTaskFailed();


    }
}
