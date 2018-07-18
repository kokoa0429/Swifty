using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerController : Photon.MonoBehaviour
{

    public GameObject status;
    public GameObject player;
    private Text statusText;
    private Text playerName;

    private bool ConnectInUpdate = true;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public virtual void Start()
    {
        statusText = status.GetComponent<Text>();
        playerName = status.GetComponent<Text>();
        PhotonNetwork.autoJoinLobby = true;
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
        Debug.Log("Jointed Lobby");
        statusText.text = "server connected logged in Lobby";

        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        for(int i = 0; i< rooms.Length; i++) {
            Debug.Log(rooms[i]);
        }
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

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        statusText.text = "server connection failed";
    }

    public void OnJoinedRoom()
    {
        if(PhotonNetwork.room.Name == "hub")
        {
            PhotonNetwork.isMessageQueueRunning = false;
            SceneManager.LoadScene("Lobby");
        }
    }
    private void OnSceneLoaded(Scene i_loadedScene, LoadSceneMode i_mode)
    {
        PhotonNetwork.isMessageQueueRunning = true;

        if (i_loadedScene.name == "Lobby")
        {
            CreatePlayerObject();
        }
    }

    void CreatePlayerObject()
    {
        Vector3 position = new Vector3(33.5f, 1.5f, 20.5f);
        PhotonNetwork.Instantiate("a Player", position, Quaternion.identity, 0);
    }


}
