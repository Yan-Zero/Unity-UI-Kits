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
using UnityUIKit.GameObjects;

namespace TaiwuUIKit.GameObjects
{
    /*
     *  按钮分三个部分：
     *  1. 父容器，其具有 CButton、PointerTrigger。
     *  2. Normal，显示正常的图片
     *  3. Hover，显示高亮图片
     *  4. Disabled，被禁用
    */

    // TODO：
    // 1. 实现黑底

    /// <summary>
    /// 太吾的按钮
    /// </summary>
    public class TaiwuButton : UnityUIKit.GameObjects.Button, Resources.Others.ITaiwuSound
    {
        /// <summary>
        /// 正常情况
        /// </summary>
        public Block Normal = null;
        /// <summary>
        /// 鼠标浮于其上
        /// </summary>
        public Block Hover = null;
        /// <summary>
        /// 鼠标点击的声音
        /// </summary>
        public string LeftClick_AudioKey
        {
            get => clickAudioKey;
            set => clickAudioKey = value;
        }
        private string clickAudioKey = "ui_default_click_left";

        /// <summary>
        /// 文本标签（实际上是 TaiwuLabel 类型的）
        /// </summary>
        private TaiwuLabel m_Label = new TaiwuLabel()
        {
            Name = "Lable"
        };
        /// <summary>
        /// 实际上是 BaseText，可以直接 as BaseText。
        /// </summary>
        public override IText Label => m_Label;
        /// <summary>
        /// 文本内容
        /// </summary>
        public string Text
        {
            get => Label?.Text;
            set
            {
                if (Label != null)
                    Label.Text = value;
            }
        }

        /// <summary>
        /// 多个放放音乐
        /// </summary>
        protected override void OnClick_Invoke()
        {
            if (!string.IsNullOrEmpty(LeftClick_AudioKey))
                AudioManager.Instance.PlaySound(LeftClick_AudioKey);
            else
                AudioManager.Instance.PlaySound("ui_default_click_left");
            base.OnClick_Invoke();
        }

        /// <summary>
        /// 创建 Button 对象
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            if(Image != null)
            {
                if (Normal == null)
                    Normal = new Block() { 
                        Name = "Normal",
                        BackgroundImage = Resources.SpriteResource.SP_Button_2_0,
                        BackgroundType = UnityEngine.UI.Image.Type.Sliced,
                        Element = Element
                    };
                Children.Add(Normal);
            }
            else
            {
                Image = Resources.SpriteResource.SP_Button_2_0;
                ImageType = UnityEngine.UI.Image.Type.Sliced;
            }
            if (Hover == null)
                Hover = new Block()
                {
                    Name = "Hover",
                    BackgroundImage = Resources.SpriteResource.SP_Button_2_1,
                    BackgroundType = UnityEngine.UI.Image.Type.Sliced,
                    Element = Element,
                    DefaultActive = true,
                };
            Children.Add(Hover);
            base.Create(active);
            if(Image == Resources.SpriteResource.SP_Button_2_0)
            {
                Normal = Children.Find((x) => x.Name == "Image") as Block;
                Normal.Name = "Normal";
            }

            PointerTrigger pointerEnter = Get<PointerTrigger>();
            pointerEnter.EnterEvent = new UnityEngine.Events.UnityEvent();
            pointerEnter.EnterEvent.AddListener(() =>
            {
                Hover.SetActive(true);
                Normal.SetActive(false);
            });
            pointerEnter.ExitEvent = new UnityEngine.Events.UnityEvent();
            pointerEnter.ExitEvent.AddListener(() =>
            {
                Hover.SetActive(false);
                Normal.SetActive(true);
            });

            Get<SelectableCursorTrigger>().CursorSpriteNameOnActive = "sp_cursor_clickable";
            Hover.Background.raycastTarget = false;
            Normal.Background.raycastTarget = false;
            Hover.RectTransform.anchorMax = Normal.RectTransform.anchorMax = new Vector2(1, 1);
            Hover.RectTransform.sizeDelta = Normal.RectTransform.sizeDelta =
            Hover.RectTransform.anchorMin = Normal.RectTransform.anchorMin = new Vector2(0, 0);

            Get<CEmptyGraphic>();
        }

        
    }
}
