using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftPanel : BasePanel
{
    public UnityEngine.UI.Button btnLeft;
    public override void Init()
    {
        btnLeft.onClick.AddListener(() =>
        {
            Camera.main.GetComponent<CameraAnimator>().TurnRight(() =>
            {
                UIManager.Instance.ShowPanel<RightPanel>();
                MusicMgr.GetInstance().PlaySound("世界观翻页", false);
            });

            //隐藏开始界面
            UIManager.Instance.HidePanel<LeftPanel>();
        });
    }
}
