using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose02 : BasePanel
{
    private UnityEngine.UI.Button _giveUp;
    private UnityEngine.UI.Button _restart;
    

    public override void Init()
    {
        _giveUp = transform.Find("GiveUp").GetComponent<UnityEngine.UI.Button>();
        _restart = transform.Find("Restart").GetComponent<UnityEngine.UI.Button>();
        MusicMgr.GetInstance().PlaySound("按钮2", false);

        if (ReferenceEquals(_restart, null) || ReferenceEquals(_giveUp, null))
        {
            Debug.LogWarning("Button name invalid or button lost.");
            return;
        }

        if (_giveUp.onClick.GetPersistentEventCount() == 0)
        {
            _giveUp.onClick.AddListener(GiveUp);
        }

        if (_restart.onClick.GetPersistentEventCount() == 0)
        {
            _restart.onClick.AddListener(Restart);
        }
    }

    public void GiveUp()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        UIManager.Instance.HidePanel<Lose02>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        UIManager.Instance.HidePanel<Lose02>();
    }
}
