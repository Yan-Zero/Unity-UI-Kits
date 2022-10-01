using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityUIKit.Components;
using UnityUIKit.Core;
using UnityUIKit.GameObjects;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 太吾风格的 Label
    /// </summary>
    public class TaiwuLabel : Container, IText
    {
        /// <summary>
        /// 风格
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// 没有黑底+字体黄色
            /// </summary>
            None,
            /// <summary>
            /// 黑底+字体黄色，25号
            /// </summary>
            WithBlackBackground,
            /// <summary>
            /// 子标题，黑底+字体灰色
            /// </summary>
            Subtile,
        }
        /// <summary>
        /// 显示类型
        /// </summary>
        public Style LableStyle = Style.None;

        /// <summary>
        /// 文本的本体
        /// </summary>
        public BaseText BaseLabel = new BaseText();
        
        /// <summary>
        /// 文本的对齐方式
        /// </summary>
        public TextAlignmentOptions Alignment
        {
            get => BaseLabel.Alignment;
            set => BaseLabel.Alignment = value;
        }
        /// <summary>
        /// 是否描边
        /// </summary>
        public bool UseOutline
        {
            get => BaseLabel.UseOutline;
            set => BaseLabel.UseOutline = value;
        }
        /// <summary>
        /// 显示文本
        /// </summary>
        public string Text
        {
            get => BaseLabel.Text;
            set => BaseLabel.Text = value;
        }

        /// <summary>
        /// 创建文本
        /// </summary>
        /// <param name="active"></param>
        /// <exception cref="ArgumentException">不支持的 LableStyle</exception>
        public override void Create(bool active)
        {
            BaseLabel._Text.Color = new Color(0.9725f, 0.902f, 0.7569f, 1);

            switch (LableStyle)
            {
                case Style.WithBlackBackground:
                    BackgroundImage = Resources.SpriteResource.Black_BGound;
                    BackgroundType = Image.Type.Sliced;
                    break;
                case Style.Subtile:
                    BackgroundImage = Resources.SpriteResource.Black_BGound;
                    BaseLabel._Text.Color = new Color(0.7412f, 0.7412f, 0.7412f, 1f);
                    BackgroundType = Image.Type.Sliced;
                    break;
                case Style.None:
                    break;
                default:
                    throw new ArgumentException($"BoxModel with {LableStyle} is not supported");
            }

            base.Create(active);

            BaseLabel.Name = $"Text.{Name}";
            BaseLabel.SetParent(this);

            BaseLabel.Apply();
        }
    }
}
