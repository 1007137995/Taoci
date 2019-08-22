using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TinyTeam.UI;

public class MainScene : MonoBehaviour
{
    public string scene;
    public static MainScene Instance;

    void Awake()
    {
        Instance = this;
        TTUIPage.ShowPage<UIMain>();
    }

    public void GoScene()
    {
        SceneManager.LoadScene(scene);
    }
}
