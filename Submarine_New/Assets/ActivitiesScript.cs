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
		shuffle(consoles);
		for (int i = 0; i < locations.Length; i++)
		{
			locations[i].GetComponent<ConsoleDisplay>().console = consoles[i];
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void shuffle(Console[] arr)
	{
		int leng = arr.Length;
		Console temp;
        int rand = 0;

        for (int i = 0; i < leng; i++)
		{
			rand = Random.Range(0, 10 - i);
			temp = arr[i];
			arr[i] = arr[rand];
			arr[rand] = temp;
		}
	}
}
