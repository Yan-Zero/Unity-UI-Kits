using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityUIKit.Core;
using UnityUIKit.GameObjects;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 太吾窗口
    /// </summary>
    public class TaiwuWindows : BaseFrame
    {
        /// <summary>
        /// 标题实例
        /// </summary>
        public TaiwuTitle TaiwuTitle;
        private string m_titleText = "Default Content";

        //public CloseButton CloseButton;

        /// <summary>
        /// 标题文本
        /// </summary>
        public string Title
        {
            get => m_titleText;
            set
            {
                m_titleText = value;

                if (TaiwuTitle != null)
                {
                    TaiwuTitle.Text = m_titleText;

                    if (string.IsNullOrEmpty(value))
                        TaiwuTitle.SetActive(false);
                    else
                        TaiwuTitle.SetActive(true);
                }
            }
        }

        /// <summary>
        /// Window，仿制 Mod 管理 UI
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            BackgroundImage = Resources.SpriteResource.Background_Windows;
            BackgroundType = Image.Type.Sliced;
            Padding = new List<int>() { 80 , 180, 120 };

            TaiwuTitle = new TaiwuTitle
            {
                Name = "Title",
                Text = m_titleText
            };
            //CloseButton = new CloseButton()
            //{
            //    Name = "Close",
            //};

            base.Create(active);
            TaiwuTitle.SetParent(this);
            TaiwuTitle.RectTransform.SetAsFirstSibling();
            //CloseButton.SetParent(this);

            //CloseButton.OnClick = delegate
            //{
            //    if (null == RectTransform.parent)
            //        GameObject.SetActive(false);
            //    else
            //        RectTransform.parent.gameObject.SetActive(false);
            //};

            //CloseButton.RectTransform.anchoredPosition = Vector2.zero;
        }
    }

}
