// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace QFramework.WuZiQi
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public class UIGameOverData : QFramework.UIPanelData
    {
        public bool BlackWin = true;
    }
    
    public partial class UIGameOver : QFramework.UIPanel
    {
        ResLoader mResLoader = ResLoader.Allocate();
        
        protected override void ProcessMsg(int eventId, QFramework.QMsg msg)
        {
            throw new System.NotImplementedException ();
        }
        
        protected override void OnInit(QFramework.IUIData uiData)
        {
            mData = uiData as UIGameOverData ?? new UIGameOverData();
            // please add init code here

            if (mData.BlackWin)
            {
                ResultImage.sprite = mResLoader.LoadSprite("BlackWin");
            }
            else
            {
                ResultImage.sprite = mResLoader.LoadSprite("WhiteWin");
            }

            // 监听鼠标点击事件
            this.Sequence()
                .Delay(1.0f)
                .Until(()=>Input.GetMouseButtonDown(0))
                .Event(()=>
                {
                    // 关闭自己
                    CloseSelf();
                    // 重新开始游戏
                    TypeEventSystem.Send<GameResetEvent>();

                })
                .Begin();
        }
        
        protected override void OnOpen(QFramework.IUIData uiData)
        {
        }
        
        protected override void OnShow()
        {
        }
        
        protected override void OnHide()
        {
        }
        
        protected override void OnClose()
        {
            mResLoader.Recycle2Cache();
            mResLoader = null;
        }
    }
}