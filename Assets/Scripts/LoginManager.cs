using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{

    InputField IF_Username;
    InputField IF_Password;
    string username;
    string password;

    public static LoginManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public void Login()
    {
        // Comprobacion de usuario contra base de datos
        Debug.Log("Comprobacion de usuario contra base de datos - Login");
    }
}
