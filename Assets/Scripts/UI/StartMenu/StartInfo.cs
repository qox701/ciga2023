using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartInfo : BasePanel
{
    [SerializeField] private string stage1 = "SampleScene";
    [SerializeField] private TextMeshProUGUI[] texts;

    private UnityEngine.UI.Button _pageDown;
    private UnityEngine.UI.Button _gameStart;

    private TextMeshProUGUI _currentPage;
    private int _pageIndex = 0;
    

    public override void Init()
    {
        //Text Initialize
        foreach (var text in texts)
        {
            text.gameObject.SetActive(false);
        }
        _currentPage = texts[0];
        _currentPage.gameObject.SetActive(true);
        _pageIndex = 0;
        
        
        //Do Button Initialize
        _pageDown = transform.Find("PageDown").GetComponent<UnityEngine.UI.Button>();
        _gameStart = transform.Find("GameStart").GetComponent<UnityEngine.UI.Button>();

        if (ReferenceEquals(_pageDown, null) || ReferenceEquals(_gameStart, null))
        {
            Debug.LogWarning("Button name invalid or button lost.");
            return;
        }

        if (_pageDown.onClick.GetPersistentEventCount() == 0)
        {
            _pageDown.onClick.AddListener(PageDown);
        }

        if (_gameStart.onClick.GetPersistentEventCount() == 0)
        {
            _gameStart.onClick.AddListener(GameStart);
        }
        _gameStart.gameObject.SetActive(false);
    }

    /// <summary>
    /// No time to find a better way. So make sure all texts u need are dragged to the right position in inspector
    /// All texts should be in the "texts" on inspector
    /// </summary>
    public void PageDown()
    {
        Debug.Log("Page down");
        _currentPage.gameObject.SetActive(false);
        _pageIndex++;
        if (_pageIndex == texts.Length - 1)
        {
            _gameStart.gameObject.SetActive(true);
        }
        if (_pageIndex >= texts.Length)
        {
            _pageIndex = 0;
            
        }
        MusicMgr.GetInstance().PlaySound("世界观翻页",false,null);
        _currentPage = texts[_pageIndex];
        _currentPage.gameObject.SetActive(true);
    }

    /// <summary>
    /// Change the way you load scene to your needed here
    /// </summary>
    public void GameStart()
    {
        
        SceneManager.LoadScene(stage1, LoadSceneMode.Single);
        UIManager.Instance.HidePanel<StartInfo>();
    }
}
