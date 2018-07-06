using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour {

    public GameObject canvas;
    public GameObject userName;

    private Text text;

    private void Start()
    {
        canvas.SetActive(false);
        text = userName.GetComponent<Text>();
    }

    public void OnClick()
    {
        canvas.SetActive(true);

        //SceneManager.LoadScene("Lobby");
    }

    public void OnApplyButtonClick()
    {

        Debug.Log(text.text);
        SceneManager.LoadScene("Lobby");
    }
}
