using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    //实例化电量
    private static Battery instance = new Battery();
    //电量
    private float eletricity=100;
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener("AddEletricity", AddEletricity);
    }
    private void Update()
    {
        Debug.Log(eletricity);
        eletricity-=Time.deltaTime;
    }
    //增加十格电量
    public void AddEletricity()
    {
        eletricity += 10;
    }
}
