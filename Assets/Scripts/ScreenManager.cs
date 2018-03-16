using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    GameObject activeScreen;
    public GameObject screen_Initial;
    public GameObject screen_LoginOrRegister;
    public GameObject screen_Login_Panel;
    public GameObject screen_Register_Panel;
    public GameObject screen_Landing;
    public GameObject screen_Profile;
    public GameObject screen_ProffesionalSearch;
    public GameObject screen_NewQuery;
    public GameObject screen_Providers;
    public GameObject screen_MyProjects;
    public GameObject navbar_Main;
    public GameObject navbar_Projects;
    public GameObject navbar_Search;
    public GameObject query1, query2, query3, query4, query5, summary;
    public List<GameObject> queries = new List<GameObject>();
    public Dropdown dropdown_birth;
    int currentQuery = 0;


    public static ScreenManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
        queries.Add(query1);
        queries.Add(query2);
        queries.Add(query3);
        queries.Add(query4);
        queries.Add(query5);
        queries.Add(summary);
    }

    private void Start()
    {
        activeScreen = screen_Initial;
        FillBirthDropdown();
        ChangeActiveScreen(screen_Initial);
        navbar_Main.SetActive(false);
        navbar_Projects.SetActive(false);
        navbar_Search.SetActive(false);
    }

    public void btn_initial_clicked(GameObject initialScreen)
    {
        ChangeActiveScreen(screen_LoginOrRegister);
    }

    public void btn_LoginOrRegister_Login_clicked()
    {
        ChangeActiveScreen(screen_Login_Panel);
    }

    public void btn_LoginOrRegister_Register_clicked()
    {
        ChangeActiveScreen(screen_Register_Panel);
    }

    public void btn_LoginOrRegister_Cancel_clicked()
    {
        ChangeActiveScreen(screen_Initial);
    }

    public void btn_LoginOrRegister_LoginPanel_Login_clicked()
    {
        LoginManager.instance.Login();
        ChangeActiveScreen(screen_Landing);
    }

    public void btn_LoginOrRegister_LoginPanel_Cancel_clicked()
    {
        ChangeActiveScreen(screen_LoginOrRegister);
    }

    public void btn_LoginOrRegister_RegisterPanel_Register_clicked()
    {
        RegisterManager.instance.Register();
        ChangeActiveScreen(screen_Landing);
    }

    public void btn_LoginOrRegister_RegisterPanel_Cancel_clicked()
    {
        ChangeActiveScreen(screen_LoginOrRegister);
    }


    public void btn_Profile_clicked()
    {
        ChangeActiveScreen(screen_Profile);
    }

    public void btn_Profile_return_clicked()
    {
        ChangeActiveScreen(screen_Landing);
    }

    public void btn_Proffesionals_clicked()
    {
        ChangeActiveScreen(screen_ProffesionalSearch);
        if (navbar_Search.activeInHierarchy)
        {
            navbar_Search.SetActive(false);
        }
    }

    public void btn_NewQuery_clicked()
    {
        ChangeActiveScreen(screen_NewQuery);
        if (navbar_Projects.activeInHierarchy)
        {
            navbar_Projects.SetActive(false);
        }
    }

    public void btn_Providers_clicked()
    {
        ChangeActiveScreen(screen_Providers);
        if (navbar_Search.activeInHierarchy)
        {
            navbar_Search.SetActive(false);
        }
    }

    public void btn_MyProjects_clicked()
    {
        Debug.Log("btn_MyProjects_clicked");
        if (navbar_Projects.activeInHierarchy)
        {
            navbar_Projects.SetActive(false);
        }
    }

    public void btn_Prev_Query()
    {
        queries[currentQuery].SetActive(false);
        queries[currentQuery - 1].SetActive(true);
        if (currentQuery >= 0)
        {
            currentQuery -= 1;
        }
    }

    public void btn_Next_Query()
    {
        queries[currentQuery].SetActive(false);
        queries[currentQuery + 1].SetActive(true);
        if (currentQuery <= 5)
        {
            currentQuery += 1;
        }
    }

    public void btn_Create_Query()
    {
        Debug.Log("Consulta creada !");
        ChangeActiveScreen(screen_MyProjects);
    }

    public void btn_Projects_clicked()
    {
        if (navbar_Search.activeInHierarchy)
        {
            navbar_Search.SetActive(false);
        }
        if (navbar_Projects.activeInHierarchy == true)
        {
            navbar_Projects.SetActive(false);
        }
        else
        {
            navbar_Projects.SetActive(true);
        }
    }

    public void btn_Search_clicked()
    {
        if (navbar_Projects.activeInHierarchy)
        {
            navbar_Projects.SetActive(false);
        }

        if (navbar_Search.activeInHierarchy == true)
        {
            navbar_Search.SetActive(false);
        }
        else
        {
            navbar_Search.SetActive(true);
        }
    }

    public void ChangeActiveScreen(GameObject screen)
    {
        activeScreen.SetActive(false);
        screen.SetActive(true);
        activeScreen = screen;
        if (activeScreen == screen_Landing)
        {
            navbar_Main.SetActive(true);
        }
    }

    public void Debug_This_GO(GameObject go)
    {
        Debug.Log("Debug -> " + go.name);
    }

    public void FillBirthDropdown()
    {
        List<string> years = new List<string>();
        for (int i = 1942; i <= 2000; i++)
        {
            years.Add(i.ToString());
        }
        dropdown_birth.AddOptions(years);
    }
}
