using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    //单例模式
    private static Battery instance;

    public static Battery Instance => instance;

    public void Awake()
    {
        instance = this;
    }

    public List<Image> eletricityList = new List<Image>();

    private int showNum;
    //实例化电量
    //private static Battery instance = new Battery();
    //电量
    private float eletricity=100;
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener("AddEletricity", AddEletricity);
    }
    private void Update()
    {
        ShowEletricity();
        eletricity-=Time.deltaTime*5;
    }
    //增加十格电量
    public void AddEletricity()
    {
        eletricity += 10;
    }
    
    private void ShowEletricity()
    {
        showNum = (int)(eletricity + 10) / 20;
        //显示电量
        for (int i = 0; i < eletricityList.Count; i++)
        {
            eletricityList[i].gameObject.SetActive(i<showNum);
        }
    }
}
