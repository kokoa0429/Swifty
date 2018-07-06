using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerController : Photon.MonoBehaviour
{

    public GameObject status;
    private Text statusText;
    
    private bool ConnectInUpdate = true;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public virtual void Start()
    {
        statusText = status.GetComponent<Text>();
        PhotonNetwork.autoJoinLobby = false;
    }

    public virtual void Update()
    {
        if (ConnectInUpdate && !PhotonNetwork.connected)
        {
            ConnectInUpdate = false;
            PhotonNetwork.ConnectUsingSettings("v0.0.1");
            statusText.text = "server connecting...";
        }
    }

    public virtual void OnConnectedToMaster()
    {
        statusText.text = "server connected";
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("Jointed Lobby, going to Hub");

        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        for(int i = 0; i< rooms.Length; i++) {
            Debug.Log(rooms[i]);
        }

        JoinHub();

}
    public void JoinHub()
    {
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        RoomOptions roomOptions = new RoomOptions();

        PhotonNetwork.JoinOrCreateRoom("hub", roomOptions, null);
    }
    

    void OnReceivedRoomListUpdate()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        if (rooms.Length == 0)
        {
            Debug.Log("room not found");
        }
        else
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                Debug.Log("RoomName:" + rooms[i].Name);
            }
        }
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");

        CreatePlayerObject();
    }

    void CreatePlayerObject()
    {
        Vector3 position = new Vector3(33.5f, 1.5f, 20.5f);

        PhotonNetwork.Instantiate("a Player", position, Quaternion.identity, 0);

        //Camera.Target = newPlayerObject.transform;
    }
}
