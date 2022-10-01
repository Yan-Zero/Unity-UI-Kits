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

        private TaiwuLabel Label = new TaiwuLabel()
        {
            Text = "Default Content",
        };

        /// <summary>
        /// 标题文本
        /// </summary>
        public string Text
        {
            get => Label.Text;
            set
            {
                Label.Text = value;
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

            Children.Add(Label);

            base.Create(active);
        }
    }
}
