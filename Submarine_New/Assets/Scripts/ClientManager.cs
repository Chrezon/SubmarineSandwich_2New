using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ClientManager : MonoBehaviourPunCallbacks
{
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
        CONNECTEDANDJOINING,
        JOINEDANDSTARTINGGAME,
    }

    ConnectionState state = ConnectionState.DISCONNECTED;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnConnectedToServer()
    {
        JoinDefaultRoom();
    }


    void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // reset connection
            PhotonNetwork.Disconnect();
        }

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
        Debug.Log(PhotonNetwork.NetworkStatisticsToString());
        this.state = ConnectionState.CONNECTING;
    }

    void JoinDefaultRoom()
    {
        RoomOptions room_options = new RoomOptions(
            );
        PhotonNetwork.JoinOrCreateRoom(
                "Default",
                room_options,
                null);
        Debug.Log("Joining room");

    }
    public override void OnConnectedToMaster()
    {
        if (this.state == ConnectionState.CONNECTING)
        {

            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room.\n Calling: PhotonNetwork.JoinRandomRoom(); Operation will fail if no room found");

            JoinDefaultRoom();
            this.state = ConnectionState.CONNECTEDANDJOINING;
        }
    }

    public override void OnJoinedRoom()
    {
        if (this.state == ConnectionState.CONNECTEDANDJOINING)
        {
            PhotonNetwork.LoadLevel("SampleScene");
            this.state = ConnectionState.JOINEDANDSTARTINGGAME;
        }
    }
}
