using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : BasePanel
{
    private UnityEngine.UI.Button _startButton;
    private UnityEngine.UI.Button _quitButton;



    public override void Init()
    {
        _startButton = transform.Find("StartButton").GetComponent<UnityEngine.UI.Button>();
        _quitButton = transform.Find("QuitButton").GetComponent<UnityEngine.UI.Button>();

        if (ReferenceEquals(_startButton, null) || ReferenceEquals(_quitButton, null))
        {
            Debug.LogWarning("Button name invalid or button lost.");
            return;
        }
        if (_startButton.onClick.GetPersistentEventCount()==0)
        {
            
            _startButton.onClick.AddListener(StartButton);
        }

        if (_quitButton.onClick.GetPersistentEventCount() == 0)
        {
            _quitButton.onClick.AddListener(QuitButton);
        }
    }


    public void StartButton()
    {
        UIManager.Instance.ShowPanel<StartInfo>();
        UIManager.Instance.HidePanel<StartMenu>();
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
#endif
    }
}
