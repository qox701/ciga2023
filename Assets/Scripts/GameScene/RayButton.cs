using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayButton : Button
{
    protected override void ButtonDown()
    {
        //�ж��Ƿ��ǿɴݻ�Ŀ�꣬tag���ֿɱ�
        if (Raycontro.hitthing == "Player")
        {
            EventCenter.GetInstance().EventTrigger("Fire");
            Debug.Log("�������ӵ�Ԥ����");
        }
        Debug.Log("Button down");
    }

    protected override void ButtonUp()
    {
        Debug.Log("Button up");
    }
}

