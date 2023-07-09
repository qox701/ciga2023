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
        Battery.Instance.isFading = false;
        UIManager.Instance.ShowPanel<Lose01>();
    }

    private void GameWin()
    {
        Battery.Instance.isFading = false;
        UIManager.Instance.ShowPanel<Victory01>();
    }

    private void AddBattery()
    {
        EventCenter.GetInstance().EventTrigger("AddEletricity", 2);
    }
}
