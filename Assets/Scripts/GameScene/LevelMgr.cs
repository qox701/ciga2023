using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    private static LevelMgr instance;

    public static LevelMgr Instance => instance;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UIManager.Instance.ShowPanel<RightPanel>();
    }
}
