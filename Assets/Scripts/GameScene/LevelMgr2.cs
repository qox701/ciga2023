using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr2 : MonoBehaviour
{
    private static LevelMgr2 instance;

    public static LevelMgr2 Instance => instance;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UIManager.Instance.ShowPanel<RightPanel>();
        EventCenter.GetInstance().AddEventListener("GameOver", GameOver);
    }

    private void OnTriggerEnter(Collider other)
    {
        GrabItem grabItem= other.GetComponent<GrabItem>();
        if (grabItem!=null)
        {
            if (grabItem.type==ItemType.Battery)
            {
                AddBattery();
                grabItem.HandInItem();
            }
            else if (grabItem.type==ItemType.Mission)
            {
                GameWin();
                grabItem.HandInItem();
                Debug.Log("Win");
            }
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowPanel<Lose02>();
    }

    private void GameWin()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowPanel<Victory02>();
    }

    private void AddBattery()
    {
        EventCenter.GetInstance().EventTrigger("AddEletricity", 1);
    }
}