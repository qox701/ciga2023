using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.ShowPanel<RightPanel>();
    }
}
