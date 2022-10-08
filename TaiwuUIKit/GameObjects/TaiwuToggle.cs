using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityUIKit.Components;
using UnityUIKit.Core;
using UnityUIKit.Core.GameObjects;
using UnityUIKit.GameObjects;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 太吾标准风格的 Toggle
    /// </summary>
    public class TaiwuToggle : UnityUIKit.GameObjects.Toggle, Resources.Others.ITaiwuSound
    { 
        /// <summary>
        /// 开关风格
        /// </summary>
        public enum ToggleType
        {
            /// <summary>
            /// 单个的（实际上就是最开始设置中的风格）
            /// </summary>
            Alone,
            /// <summary>
            /// 现在的
            /// </summary>
            Now,
        }
        /// <summary>
        /// 开关风格
        /// </summary>
        public ToggleType Style = ToggleType.Now;

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
                if (Created) Get<MouseTipDisplayer>().PresetParam = tipParm.ToArray();
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
                if (Created) Get<MouseTipDisplayer>().PresetParam = tipParm.ToArray();
            }
        }

        /// <summary>
        /// 文本标签（实际上是 TaiwuLabel 类型的）
        /// </summary>
        private TaiwuLabel m_Label = new TaiwuLabel()
        {
            Name = "Lable"
        };
        /// <summary>
        /// 实际上是 TaiwuLabel，可以直接 as TaiwuLabel。
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
        /// 使用 OutLine
        /// </summary>
        public bool UseOutline
        {
            get => (Label as BaseText).UseOutline;
            set
            {
                (Label as BaseText).UseOutline = value;
            }
        }
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
        /// 动画变更
        /// </summary>
        /// <param name="isOn"></param>
        protected override void OnValueChanged_Invoke(bool isOn)
        {
            if (isOn)
            {
                if (Style == ToggleType.Alone)
                {
                    Hover?.Children[0].SetActive(true);
                    Hover?.Children[1].SetActive(false);
                    Normal?.Children[0].SetActive(true);
                    Normal?.Children[1].SetActive(false);
                }
            }
            else
            {
                if (Style == ToggleType.Alone)
                {
                    Normal?.Children[1].SetActive(true);
                    Hover?.Children[1].SetActive(true);
                    Hover?.Children[0].SetActive(false);
                    Normal?.Children[0].SetActive(false);
                }
            }
            base.OnValueChanged_Invoke(isOn);
        }
        /// <summary>
        /// Hover 的组件
        /// </summary>
        public Block Hover = null;
        /// <summary>
        /// Normal/Off 的组件
        /// </summary>
        public Block Normal = null;
        /// <summary>
        /// On 的组件
        /// </summary>
        public Block On = null;
        /// <summary>
        /// 创建组件
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active = true)
        {
            if (Element.PreferredSize.Count == 0)
                Element.PreferredSize = PreferredSize;

            Image = Style == ToggleType.Alone ? 
                Resources.SpriteResource.Toggle_Hover_OLD : Resources.SpriteResource.Toggle_Hover;
            ImageType = UnityEngine.UI.Image.Type.Sliced;
            Normal = Style == ToggleType.Alone ? new Block()
            {
                Name = "Normal",
                BackgroundImage = Resources.SpriteResource.Toggle_Normal_OLD,
                BackgroundType = UnityEngine.UI.Image.Type.Sliced,
                Children =
                {
                    new BoxPlainGameObject()
                    {
                        Name = "On",
                        Rect =
                        {
                            AnchorMin = new Vector2(1,1),
                            AnchorMax = new Vector2(1,1),
                            SizeDelta = new Vector2(19, 18),
                            AnchoredPosition = new Vector2(-7.5f, -7.2f)
                        },
                        DefaultActive = IsOn
                    },
                    new BoxPlainGameObject()
                    {
                        Name = "Off",
                        Rect =
                        {
                            AnchorMin = new Vector2(1,1),
                            AnchorMax = new Vector2(1,1),
                            SizeDelta = new Vector2(10, 10),
                            AnchoredPosition = new Vector2(-7.5f, -7.2f)
                        },
                        DefaultActive = !IsOn
                    }
                }
            } : new Block()
            {
                Name = "Off",
                BackgroundImage = Resources.SpriteResource.Toggle_Off,
                BackgroundType = UnityEngine.UI.Image.Type.Sliced,
            };
            Children.Add(Normal);
            if(Style != ToggleType.Alone)
            {
                On = new Block
                {
                    Name = "On",
                    BackgroundImage = Resources.SpriteResource.Toggle_On,
                    BackgroundType = UnityEngine.UI.Image.Type.Sliced,
                };
                Children.Add(On);
            }
            base.Create(active);
            if (Style == ToggleType.Alone)
            {
                Normal.Children[0].Get<Image>().sprite = Resources.SpriteResource.TPatch_Hover;
                Normal.Children[1].Get<Image>().sprite = Resources.SpriteResource.TPatch_Normal;
            }
            else
            {
                On.RectTransform.anchorMax = new Vector2(1, 1);
                On.RectTransform.sizeDelta = On.RectTransform.anchorMin = new Vector2(0, 0);
            }

            var Label = this.Label as TaiwuLabel;
            Label.SetParent(this);
            UnityEngine.Object.Destroy(Label.BaseLabel.Get<ContentSizeFitter>());
            Label.Get<LayoutElement>().ignoreLayout = true;
            Label.RectTransform.sizeDelta = Vector2.zero;
            Label.RectTransform.anchoredPosition = Vector2.zero;
            Label.RectTransform.anchorMin = Vector2.zero;
            Label.RectTransform.anchorMax = Vector2.one;
            if (!string.IsNullOrEmpty(TipTitle) || !string.IsNullOrEmpty(TipContent))
            {
                Get<MouseTipDisplayer>().PresetParam = tipParm.ToArray();
                Get<MouseTipDisplayer>().Type = TipType.Simple;
            }
            var Toggle = Get<UnityEngine.UI.Toggle>();
            Toggle.image = null;
            Toggle.transition = Selectable.Transition.None;


            // 虽然此刻 Hover 自己有背景，但是可以被子对象覆盖。
            Hover = Children.Find((x) => x.Name == "Image") as Block;
            Hover.Name = "Hover";
            if(Style == ToggleType.Alone)
            { 
                Hover.Children = new List<ManagedGameObject>(){
                    new BoxPlainGameObject()
                    {
                        Name = "On",
                        Rect =
                        {
                            AnchorMin = new Vector2(1,1),
                            AnchorMax = new Vector2(1,1),
                            SizeDelta = new Vector2(19, 18),
                            AnchoredPosition = new Vector2(-7.5f, -7.2f)
                        },
                        DefaultActive = IsOn
                    },
                    new BoxPlainGameObject()
                    {
                        Name = "Off",
                        Rect =
                        {
                            AnchorMin = new Vector2(1,1),
                            AnchorMax = new Vector2(1,1),
                            SizeDelta = new Vector2(10, 10),
                            AnchoredPosition = new Vector2(-7.5f, -7.2f)
                        },
                        DefaultActive = !IsOn
                    },
                };
                foreach (var i in Hover.Children) i.SetParent(Hover);
                Hover.Children[0].Get<Image>().sprite = Resources.SpriteResource.TPatch_Hover;
                Hover.Children[1].Get<Image>().sprite = Resources.SpriteResource.TPatch_Normal;
            }

            Hover.RectTransform.anchorMax = Normal.RectTransform.anchorMax = new Vector2(1, 1);
            Hover.RectTransform.sizeDelta = Normal.RectTransform.sizeDelta =
            Hover.RectTransform.anchorMin = Normal.RectTransform.anchorMin = new Vector2(0, 0);

            Hover.SetActive(false);
            PointerTrigger pointerEnter = Get<PointerTrigger>();
            pointerEnter.EnterEvent = new UnityEngine.Events.UnityEvent();
            pointerEnter.EnterEvent.AddListener(() =>
            {
                Hover.SetActive(true);
                Normal.SetActive(false);
                On?.SetActive(false);
            });
            pointerEnter.ExitEvent = new UnityEngine.Events.UnityEvent();
            pointerEnter.ExitEvent.AddListener(() =>
            {
                Hover.SetActive(false);
                On?.SetActive(IsOn);
                Normal.SetActive(!IsOn || On == null);
            });

            Get<SelectableCursorTrigger>().CursorSpriteNameOnActive = "sp_cursor_clickable";
            Get<Resources.Others.PClick>()._Parent = this;
            Get<CEmptyGraphic>();
        }
    }
}
