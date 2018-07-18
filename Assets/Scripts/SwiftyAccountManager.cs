using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SwiftyAccountManager : MonoBehaviour {

    public bool isLoggedin = false;

    private string token = null;

    public  IEnumerator Login(string name, string password)
    {
        Debug.Log("login ienumerator");

        //List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        //formData.Add(new MultipartFormDataSection("name=foo&password=bar"));
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post("https://api.ciebus.net/swifty/login.php", form);
        yield return www.SendWebRequest();
       

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(www.downloadHandler.text);
        }
    }


    

}
