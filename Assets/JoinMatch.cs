using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinMatch : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LeaveRoom();
        //PhotonNetwork.JoinOrCreateRoom("match",null,null);
        SceneManager.LoadScene("GameStage");
    }
}
