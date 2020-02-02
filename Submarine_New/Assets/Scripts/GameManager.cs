using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

/// <summary>
/// Game manager.
/// Connects and watch Photon Status, Instantiate Player
/// Deals with quiting the room and the game
/// Deals with level loading (outside the in room synchronization)
/// </summary>
public class GameManager : MonoBehaviourPunCallbacks
{
    #region Public Fields

    static public GameManager Instance;

    #endregion

    public Console[] consoles = new Console[10];
    public GameObject[] locations = new GameObject[5];
    public GameObject[] players = new GameObject[2];

    void Start()
    {
        int temp = 0;
        for (int i = 0; i < locations.Length; i++)
        {
            temp = Random.Range(0, 10);
            locations[i].GetComponent<ConsoleDisplay>().console = consoles[temp];
        }

        Instance = this;
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Dummy");
            return;
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