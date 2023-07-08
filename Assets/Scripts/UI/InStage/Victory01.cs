using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory01 : BasePanel
{
    private UnityEngine.UI.Button _nextStage;
    [SerializeField] private string nextStage = "SampleScene";

    
    public override void Init()
    {
        _nextStage = transform.Find("NextStage").GetComponent<UnityEngine.UI.Button>();
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
        SceneManager.LoadScene(nextStage, LoadSceneMode.Single);
        UIManager.Instance.HidePanel<Victory01>();
    }
}
