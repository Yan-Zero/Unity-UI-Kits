using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityUIKit.Core;
using UnityUIKit.Core.GameObjects;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 滑条
    /// </summary>
    public class TaiwuSlider : UnityUIKit.GameObjects.Slider, Resources.Others.ITaiwuSound
    {
        private List<string> tipParm = new List<string>() { "", "" };
        /// <summary>
        /// Tip 的标题
        /// </summary>
        public string TipTitle
        {
            get => tipParm[0];
            set
            {
                tipParm[0] = value;
                if (Created) Handle.Get<MouseTipDisplayer>().PresetParam = tipParm.ToArray();
            }
        }
        /// <summary>
        /// Tip 的 内容
        /// </summary>
        public string TipContent
        {
            get => tipParm[1];
            set
            {
                tipParm[1] = value;
                if (Created) Handle.Get<MouseTipDisplayer>().PresetParam = tipParm.ToArray();
            }
        }
        /// <summary>
        /// 左击的音乐
        /// </summary>
        public string LeftClick_AudioKey
        {
            get => clickAudioKey;
            set => clickAudioKey = value;
        }
        private string clickAudioKey = "ui_default_click_left";

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            BackgroundImage = Resources.SpriteResource.SliderBG;
            BackgroundType = Image.Type.Sliced;
            SliderHandleImage = Resources.SpriteResource.SliderHandle_Normal;

            if (Element.PreferredSize.Count == 0)
                Element.PreferredSize = new List<float>() { 0, 10 };

            base.Create(active);

            if (!string.IsNullOrEmpty(TipTitle) || !string.IsNullOrEmpty(TipContent))
            {
                Handle.Get<MouseTipDisplayer>().PresetParam = tipParm.ToArray();
                Handle.Get<MouseTipDisplayer>().Type = TipType.Simple;
            }

            UnitySlider.spriteState = new SpriteState()
            {
                highlightedSprite = Resources.SpriteResource.SliderHandle_Hover,
                pressedSprite = Resources.SpriteResource.SliderHandle_Hover,
                disabledSprite = Resources.SpriteResource.SliderHandle_Disabled,
            };
            UnitySlider.transition = Selectable.Transition.SpriteSwap;

            //// 下边是整数条的实现，但是太麻烦了，TODO LIST
            //if (WholeNumber)
            //{
            //    var i = new UnityUIKit.GameObjects.Container()
            //    {
            //        Name = "DotGounp",
            //        Group =
            //        {
            //            Padding = {0},
            //            Direction = UnityUIKit.Core.Direction.Horizontal,
            //            ChildrenAlignment = TextAnchor.MiddleLeft
            //        },
            //    };
            //    for(int j = (int)MinValue; j < MaxValue; ++j)
            //    {
            //        i.Children.Add(new BoxPlainGameObject()
            //        {
            //            Rect =
            //            {
            //                SizeDelta = new Vector2(8, 10)
            //            }
            //        });
            //    }
            //    i.SetParent(this);
            //    foreach(var j in i.Children)
            //        j.Get<Image>().sprite = Resources.SpriteResource.SliderDot;
            //}

            BackgroundContainer.RectTransform.anchorMin = new Vector2(0, 0.5f);
            BackgroundContainer.RectTransform.anchorMax = new Vector2(1, 0.5f);
            BackgroundContainer.RectTransform.sizeDelta = new Vector2(-40, 10);


            Handle.RectTransform.sizeDelta = new Vector2(41, 31);
            Handle.Parent.RectTransform.sizeDelta = new Vector2(-40, 0);

            Get<Resources.Others.PClick>()._Parent = this;
            Handle.Get<SelectableCursorTrigger>().CursorSpriteNameOnActive = "sp_cursor_clickable";
        }
    }
}
