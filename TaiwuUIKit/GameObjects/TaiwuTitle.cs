using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityUIKit.Core;
using UnityUIKit.GameObjects;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 标题栏
    /// </summary>
    public class TaiwuTitle : Container
    {
        /// <summary>
        /// 文本方向
        /// </summary>
        public Direction Direction = Direction.Vertical;

        private string text = "Default Content";
        private TMPLabel Label;

        /// <summary>
        /// 标题文本
        /// </summary>
        public string Text
        {
            get => text;
            set
            {
                text = value;
                if (Label != null)
                {
                    Label._Text.Content = text;
                    Label.Apply();
                }
            }
        }

        /// <summary>
        /// 创建标题对象
        /// </summary>
        /// <param name="active">激活与否</param>
        public override void Create(bool active)
        {
            BackgroundImage = Resources.SpriteResource.SP_Title_Big_2;
            BackgroundType = Image.Type.Sliced;

            // Default padding
            Group.Direction = Direction;
            Group.Padding = new List<int>() { 0 };
            Group.ChildrenAlignment = TextAnchor.MiddleCenter;

            Element.PreferredSize = new List<float> { 0, 50 };

            base.Create(active);

            // Default Label
            Label = new TMPLabel()
            {
                Name = "Text",
                _Text =
                {
                    FontSize = 24,
                    Font = Resources.Others.Font_GB2312,
                    Color = new Color(0.9725f, 0.902f, 0.7569f, 1),
                    Content = text
                }
            };

            Label.SetParent(RectTransform);

        }
    }
}
