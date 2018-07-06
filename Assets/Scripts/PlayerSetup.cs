using UnityEngine;


public class PlayerSetup : Photon.MonoBehaviour
{

    [SerializeField]
    Behaviour[] disableComponents;
    Camera sceneCamera;

    private void Start()
    {
        if (!photonView.isMine)
        {
            //Debug.Log("isNotMine");
            for(int i = 0; i< disableComponents.Length; i++)
            {
                disableComponents[i].enabled = false;
            }
        }
        else
        {

           // Debug.Log("Mine");
            sceneCamera = Camera.main;
            if(sceneCamera != null)
           sceneCamera.gameObject.SetActive(false);
        }


    }
    private void OnDisable()
    {
        if (sceneCamera != null)
            sceneCamera.gameObject.SetActive(true);
    }

}
