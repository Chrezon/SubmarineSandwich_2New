using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesScript : MonoBehaviour
{
	public Console[] consoles = new Console[10];
	public GameObject[] locations = new GameObject[5];
    public float timePerSequence = 30f;
	private float timeElapsed = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        // randomizes each console on screen
		shuffle(consoles);
		for (int i = 0; i < locations.Length; i++)
		{
			locations[i].GetComponent<ConsoleDisplay>().console = consoles[i];
		}
    }

    // Update is called once per frame
    void Update()
    {
		timePerSequence -= Time.deltaTime;
		timeElapsed += Time.deltaTime;

		ArrayList<>[] currentSequence = new ArrayList<>[2];


		if (timePerSequence == 0 && currentSequence[0].Count != 0)
		{
            // Death function call here 
		}
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

    void gameOver()
	{

	}
}
