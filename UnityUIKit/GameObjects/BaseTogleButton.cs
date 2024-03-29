﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityUIKit.Components;
using UnityUIKit.Core;
using UnityUIKit.Core.GameObjects;
using static UnityUIKit.GameObjects.Container;

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
        public virtual IText Label
        {
            get => null;
        }

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

            if(Label != null)
            {
                var i = new FitterContainer()
                {
                    Name = "LableRoot",
                    Group =
                    {
                        Direction = Direction.Horizontal,
                    }
                };
                i.SetParent(this);
                Label.SetParent(i);
                i.RectTransform.anchorMin = i.RectTransform.sizeDelta = Vector2.zero;
                i.RectTransform.anchorMax = Vector2.one;
            }
        }
    }
}
