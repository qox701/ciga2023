using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory02 : BasePanel
{
    private UnityEngine.UI.Button _backButton;

    

    public override void Init()
    {
        _backButton = transform.Find("Back").GetComponent<UnityEngine.UI.Button>();
        MusicMgr.GetInstance().PlaySound("通关3", false);
        if (ReferenceEquals(_backButton, null))
        {
            Debug.LogWarning("Button name invalid or button lost.");
            return;
        }

        if (_backButton.onClick.GetPersistentEventCount() == 0)
        {
            _backButton.onClick.AddListener(BackToMenu);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        UIManager.Instance.HidePanel<Victory02>();
    }
}
