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
public class GameManager : MonoBehaviour
{
    #region Public Fields


    #endregion

    public Console[] consoles = new Console[5];
    public GameObject[] locations = new GameObject[5];
    
    void Start()
    {
        //shuffle(consoles);
        for (int i = 0; i < locations.Length; i++)
        {
            locations[i].GetComponent<ConsoleDisplay>().console = consoles[i];
        }

        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("GameOver");
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
            rand = Random.Range(0, 5 - i);
            temp = arr[i];
            arr[i] = arr[rand];
            arr[rand] = temp;
        }
    }
}
