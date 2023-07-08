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

    //控制电量显示
    public List<Image> eletricityList = new List<Image>();
    private int showNum;
    
    //电量相关
    private float eletricity=100;
    public float decreaseSpeed=1;
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener<int>("AddEletricity", AddEletricity);
    }
    private void Update()
    {
        ShowEletricity();
        eletricity-=Time.deltaTime*decreaseSpeed;
    }
    
    //增加十格电量
    public void AddEletricity(int i)
    {
        eletricity += 20*i;
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
