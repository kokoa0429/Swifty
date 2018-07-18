using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//没コード

public class PasswordController : MonoBehaviour {

    public Text text;

    public string passwordtext = "";

    private void Update()
    {
        if (text.text.Length > 0)
        {
            char password = text.text[text.text.Length - 1];

            if (passwordtext.Length < text.text.Length)
            {
                passwordtext += password;

                string hide = "";
                for (int i = 0; i < text.text.Length; i++)
                {
                    hide += '*';
                }
                //Debug.Log(hide);
                text.text = hide;
            }
        }


    }



}
