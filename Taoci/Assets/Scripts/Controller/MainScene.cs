using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;

public class MainScene : MonoBehaviour
{
    void Awake()
    {
        TTUIPage.ShowPage<UIMain>();
    }
}
