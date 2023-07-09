using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory01 : BasePanel
{
    private UnityEngine.UI.Button _nextStage;
    [SerializeField] private string nextStage = "GameSceneLevel2";

    
    public override void Init()
    {
        _nextStage = transform.Find("NextStage").GetComponent<UnityEngine.UI.Button>();
        MusicMgr.GetInstance().PlaySound("通关3", false);
        if (ReferenceEquals(_nextStage, null))
        {
            Debug.LogWarning("Button name invalid or button lost.");
            return;
        }

        if (_nextStage.onClick.GetPersistentEventCount() == 0)
        {
            _nextStage.onClick.AddListener(NextStage);
        }
    }

    public void NextStage()
    {
        SceneManager.LoadScene(nextStage);
        MonoMgr.GetInstance().RemoveUpdateListener(MusicMgr.GetInstance().Update);
        //ScenesMgr.GetInstance().LoadScene(nextStage,null);
        UIManager.Instance.HidePanel<Victory01>();
    }
}
