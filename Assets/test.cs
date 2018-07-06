using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    private PhotonView photonView;
    private PhotonTransformView photonTransformView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        photonTransformView = GetComponent<PhotonTransformView>();
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            //現在の移動速度
            var velocity = GetComponent<Rigidbody>().velocity ;
            //移動速度を指定
            photonTransformView.SetSynchronizedValues(speed: velocity, turnSpeed: 0);
        }
    }


}
