using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesScript : MonoBehaviour
{
	public Console[] consoles = new Console[10];
	public GameObject[] locations = new GameObject[5];
    public float timePerSequence = 30f;
	private float timeElapsed = 0f;
	private string letters = "abcdefghijklmnopqrstuvwxyz";
    // Start is called before the first frame update
    void Start()
    {
        // randomizes each console on screen
		shuffle(consoles);
		for (int i = 0; i < locations.Length; i++)
		{
			locations[i].GetComponent<ConsoleDisplay>().console = consoles[i];
		}
		shuffle(consoles);
    }

    // Update is called once per frame
    void Update()
    {
		timePerSequence -= Time.deltaTime;
		timeElapsed += Time.deltaTime;

		ArrayList currentSequence = newSequence();

		if (currentSequence.Count == 0)
		{
			currentSequence = newSequence();
		} else if (timePerSequence == 0)
		{
			//LifeBarScript.decrementHealth();
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

    private ArrayList newSequence()
	{
		ArrayList sequence = new ArrayList();
		string[] action = new string[2];
        for (int i = 0; i < 8; i++)
		{
			action[0] = consoles[i].name;
			action[1] = letters[Random.Range(0, letters.Length)].ToString();
			sequence.Add(action);
		}
		return sequence; 
	}
}

