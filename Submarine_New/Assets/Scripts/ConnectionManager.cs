using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


// this class will in charge of connecting the Player to the server, 
// and it will start the game automatically after 2 Players had joined the room
public class ConnectionManager : MonoBehaviourPunCallbacks
{
    #region Public Fields 
    public string GameScene;    

    #endregion

    #region Private Serializable Fields

    #endregion

    #region Private Fields

    /// <summary>
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// </summary>
    string gameVersion = "1";

    enum ConnectionState
    {
        DISCONNECTED,
        CONNECTING,
        CONNECTED,
        WAITING,
        START,
    }

    ConnectionState state = ConnectionState.DISCONNECTED;

    #endregion


    // this will try to run the game
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {

    }



    #region Private methods
    /// <summary>
    /// the function will try to connect to the photon network, 
    /// </summary>
    private void Connect()
    {
        // we check if we are connected or not,
        if (PhotonNetwork.IsConnected)
        {
            // reset connection
            PhotonNetwork.Disconnect();
        }

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
        Debug.Log(PhotonNetwork.NetworkStatisticsToString());

        // Expecting OnConnectedToMaster while in this state
        this.state = ConnectionState.CONNECTING;
    }
    /// <summary>
    /// this function will try to join a room if connected to master server
    /// </summary>
    private void JoinDefaultRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            RoomOptions room_options = new RoomOptions
            {
                MaxPlayers = 2
            };
            PhotonNetwork.JoinOrCreateRoom(
                    "Default",
                    room_options,
                    null);
            Debug.Log("Joining room");
            this.state = ConnectionState.CONNECTED;
        }
    }

    private void TryStartGame()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            this.state = ConnectionState.START;
            PhotonNetwork.LoadLevel(this.GameScene);
        }
        else
        {
            this.state = ConnectionState.WAITING;
        }
    }
    #endregion

    #region PUN CALLBACKS

    public override void OnConnectedToMaster()
    {
        if (state == ConnectionState.CONNECTING)
        {
            Debug.Log("Connected to master");

            JoinDefaultRoom();
        }
    }

    public override void OnJoinedRoom()
    {
        if (state == ConnectionState.CONNECTED)
        {
            Debug.Log("Joined a room");
            Debug.Log(PhotonNetwork.CurrentRoom.ToString());
            TryStartGame();
        }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (state == ConnectionState.WAITING)
        {
            TryStartGame();
        }
    }

    
    #endregion
}
