using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityUIKit.Core;
using UnityUIKit.Core.GameObjects;
using UnityUIKit.GameObjects;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 异形按钮，关闭。Clone 自系统设置。
    /// </summary>
    public class CloseButton : TaiwuButton
    {
        /// <summary>
        /// 创建关闭按钮
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            Element.FlexibleSize = new List<float>() { 105 };

            Image = Resources.SpriteResource.No_Normal;
            Normal = new Block()
            {
                Name = "Normal",
                Element = Element,
                BackgroundImage = Resources.SpriteResource.Rhombus_Normal,
                DefaultActive = true
            };
            Hover = new Block()
            {
                Name = "Hover",
                Element = Element,
                BackgroundImage = Resources.SpriteResource.Rhombus_Hover,
                DefaultActive = false,
            };

            base.Create(active);
            Get<LayoutElement>().ignoreLayout = true;

            RectTransform.anchorMax = new Vector2(0.97f, 0.97f);
            RectTransform.anchorMin = RectTransform.anchorMax;
            RectTransform.anchoredPosition = Vector2.zero;
            (RectTransform.Find("Image") as RectTransform).sizeDelta = new Vector2(42, 42);

            var ClickRect = new BoxPlainGameObject()
            {
                Name = "ClickRect"
            };
            Children.Add(ClickRect);
            ClickRect.SetParent(this);
            ClickRect.Get<CEmptyGraphic>();
            ClickRect.RectTransform.sizeDelta = new Vector2(75, 75);
            ClickRect.RectTransform.eulerAngles = new Vector3(0, 0, 45);

            LeftClick_AudioKey = "ui_default_cancel";
        }
    }
}
