using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityUIKit.Components;
using UnityUIKit.Core;
using UnityUIKit.Core.GameObjects;

namespace UnityUIKit.GameObjects
{
    /// <summary>
    /// Toggle 与 Button 的基类
    /// </summary>
    [Serializable]
    public class BaseTogleButton : BoxElementGameObject
    {
        /// <summary>
        /// 给子类用的 m_interactable
        /// </summary>
        protected bool m_interactable = true;

        /// <summary>
        /// 可交互
        /// </summary>
        public virtual bool Interactable
        {
            get => m_interactable;
            set
            {
                m_interactable = value;
            }
        }

        /// <summary>
        /// 按钮图片
        /// </summary>
        public Sprite Image = null;
        /// <summary>
        /// 颜色
        /// </summary>
        public Color? ImageColor = null;
        /// <summary>
        /// 类型
        /// </summary>
        public Image.Type ImageType = UnityEngine.UI.Image.Type.Simple;

        /// <summary>
        /// 文本托管的实例。
        /// </summary>
        public IText Text = null;

        /// <summary>
        /// 创建对像
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            Children.Add(new Block()
            {
                Name = "Image",
                BackgroundColor = ImageColor,
                BackgroundImage = Image,
                BackgroundType = ImageType,
            });

            base.Create(active);

            if(Text != null)
            {
                //创建文本
                Text.Create(active);
                Text.SetParent(this);
            }
        }
    }
}
