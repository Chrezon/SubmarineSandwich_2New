using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesScript : MonoBehaviour
{
	public Console[] consoles = new Console[10];
	public GameObject[] locations = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
		int temp = 0; 
		for (int i = 0; i < locations.Length; i++)
		{
			temp = Random.Range(0, 10);
			locations[i].GetComponent<ConsoleDisplay>().console = consoles[temp];
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
