using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour {

    InputField IF_user;
    InputField IF_password;
    InputField IF_name;
    InputField IF_dob;
    Dropdown dd_category;
    string databaseURL;

    public static RegisterManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public void Register()
    {
        //StartCoroutine(RegisterCR());
        Debug.Log("Register Coroutine");
    }
    public IEnumerator RegisterCR()
    {
        WWWForm form = new WWWForm();

        form.AddField(IF_user.text, "user");
        form.AddField(IF_password.text, "password");
        form.AddField(IF_name.text, "name");
        form.AddField(IF_dob.text, "dob");
        form.AddField(dd_category.captionText.text, "dob");

        UnityWebRequest UWR = UnityWebRequest.Post(databaseURL, form);

        yield return UWR.SendWebRequest();

    }
}
