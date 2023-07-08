using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightPanel : BasePanel
{
    public UnityEngine.UI.Button btnRight;
    public override void Init()
    {
        btnRight.onClick.AddListener(() =>
        {
            //播放摄像机 左转动画 然后 再显示选角面板
            Camera.main.GetComponent<CameraAnimator>().TurnLeft(() =>
            {
                UIManager.Instance.ShowPanel<LeftPanel>();
            });

            //隐藏开始界面
            UIManager.Instance.HidePanel<RightPanel>();
        });
    }
}
