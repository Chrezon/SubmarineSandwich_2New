using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameMaster : MonoBehaviourPunCallbacks
{
	public Console[] consoles = new Console[10];
	public GameObject[] locations = new GameObject[5];
	public int task_number = new int();
	ArrayList currentSequence = new ArrayList();
	public float timePerSequence = 30f;
	private float timeElapsed = 0f;
	private string letters = "abcdefghijklmnopqrstuvwxyz";

	public int health = 3;
    public TaskList tasks = new TaskList { };

    public class TaskList
    {
        public List<string> machines;
        public List<string> buttons;

        public void Add(string machine, string button)
        {
            this.machines.Add(machine);
            this.buttons.Add(button);
        }

    }
	public TaskList generateTaskList(Console[] consoles)
	{
		List<string> cc = new List<string>();
		foreach (Console x in consoles){
			cc.Add(x.ToString());
		}


		List<string> machines = new List<string>();

		TaskList result = new TaskList();
		System.Random rnd = new System.Random();
		for (int i = 0; i < this.task_number; i++)
		{
			var index = rnd.Next(cc.Count);
			result.Add(cc[index], "A");
			cc.RemoveAt(index);			
		}
		return result;
	}

    // Start is called before the first frame update
    void Start()
    {
		    
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("live!!");
    }

	private void shuffle(Console[] arr)
	{
		int leng = arr.Length;
		Console temp;
		int rand = 0;
		for (int i = 0; i < leng; i++)
		{
			rand = Random.Range(0, 10);
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


	[PunRPC]
	public bool performAction(string cons, string input)
	{
		bool success = false;
		string[] curr = (string[])currentSequence[0];
		if (cons.Equals(curr[0]) && input.Equals(curr[1]))
		{
			success = true;
			currentSequence.RemoveAt(0);
		}
		return success;
	}
}
