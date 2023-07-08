using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayButton : Button
{
    protected override void ButtonDown()
    {
        //判断是否是可摧毁目标，tag名字可变
        if (Raycontro.hitthing == "Destroyable")
        {
            EventCenter.GetInstance().EventTrigger("Fire");
            Debug.Log("生成了子弹预制体");
        }
        Debug.Log("Button down");
    }

    protected override void ButtonUp()
    {
        Debug.Log("Button up");
    }
}

