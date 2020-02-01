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
        shuffle(consoles);
        for (int i = 0; i < locations.Length; i++)
        {
            locations[i].GetComponent<ConsoleDisplay>().console = consoles[i];
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

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.Log("OnPlayerEnteredRoom() " + other.NickName); // not seen if you're the player connecting

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

            GameObject player = PhotonNetwork.InstantiateSceneObject("player", new Vector3(0f, 0f, 0f),new Quaternion (0f, 0f, 0f, 0f));
            
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
}
