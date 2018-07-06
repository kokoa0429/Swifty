using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon playerWeapon;

    private PhotonView pv;

    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        if (playerCamera == null)
        {
            Debug.LogError("Camera Not found!");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit _hit;
        if (pv.isMine && Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out _hit, playerWeapon.range, mask))
        {
            Debug.Log(_hit.collider.name);
            //クリックした付近のコライダーを取得
            Collider[] cols = Physics.OverlapSphere(_hit.point, 3f);
            foreach (Collider target in cols)
            {
                Debug.Log(target.name);
                //範囲内のゲームオブジェクト全てのRigidbodyにAddExplosionForceする
                if (target.GetComponent<Rigidbody>())
                {
                    //target.GetComponent<Rigidbody>().AddExplosionForce(1000f, _hit.point, 100f);
                   // AddExplosion();
                    pv.RPC("AddExplosion", PhotonTargets.AllViaServer);
                }

            }
        }
    }
    [PunRPC]
    private void AddExplosion()
    {
        Debug.Log("b");
    }
}
