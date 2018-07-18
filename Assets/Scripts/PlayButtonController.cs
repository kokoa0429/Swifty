using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour {
    
    public ServerController sc;
    
    public void OnClick()
    {
        sc.JoinHub();
    }
}
