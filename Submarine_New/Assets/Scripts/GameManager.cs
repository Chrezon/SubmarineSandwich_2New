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

    void Start()
    {
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
}
