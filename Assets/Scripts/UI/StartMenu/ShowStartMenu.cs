using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStartMenu : MonoBehaviour
{
    private StartMenu _startMenu;

    private void Awake()
    {
        _startMenu = UIManager.Instance.ShowPanel<StartMenu>();
    }
}
