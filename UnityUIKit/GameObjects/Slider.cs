using System;
using UnityUIKit.Components;
using UnityUIKit;
using UnityEngine.UI;
using UnityUIKit.Core.GameObjects;
using UnityUIKit.Core;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnityUIKit.GameObjects
{
    /// <summary>
    /// 滑条
    /// </summary>
    public class Slider : BoxElementGameObject
    {
        /// <summary>
        /// 背景图片
        /// </summary>
        public Sprite BackgroundImage = null;
        /// <summary>
        /// 背景类型
        /// </summary>
        public Image.Type BackgroundType = Image.Type.Simple;
        /// <summary>
        /// 滑条的 Handle
        /// </summary>
        public Sprite SliderHandleImage = null;
        /// <summary>
        /// 填充区域的 Sprite
        /// </summary>
        public Sprite FillAreaImage = null;
        /// <summary>
        /// 填充图片的 Type
        /// </summary>
        public Image.Type FillAreaType = Image.Type.Simple;
        /// <summary>
        /// Handle 的类型
        /// </summary>
        public Image.Type SliderHandleType = Image.Type.Simple;

        /// <summary>
        /// 拖拽的按钮
        /// </summary>
        protected BoxPlainGameObject Handle;
        /// <summary>
        /// 懒得托管
        /// </summary>
        public UnityEngine.UI.Slider UnitySlider;
        /// <summary>
        /// 背景
        /// </summary>
        public BoxElementGameObject BackgroundContainer;

        /// <summary>
        /// 最大值
        /// </summary>
        protected float m_MaxValue = 100;
        protected float m_MinValue = 0;
        protected float m_NormalizedValue = 50;
        protected float m_Value = 50;
        protected bool m_wholeNumber = false;
        protected bool m_interactable = true;

        /// <summary>
        /// 可交互性
        /// </summary>
        public bool Interactable
        {
            get => m_interactable;
            set
            {
                m_interactable = value;
                if (UnitySlider) UnitySlider.interactable = m_interactable;
            }
        }
        /// <summary>
        /// 最大值
        /// </summary>
        public float MaxValue
        {
            get => m_MaxValue;
            set
            {
                m_MaxValue = value;
                if (UnitySlider) UnitySlider.maxValue = m_MaxValue;
            }
        }
        /// <summary>
        /// 最小值
        /// </summary>
        public float MinValue
        {
            get => m_MinValue;
            set
            {
                m_MinValue = value;
                if(UnitySlider) UnitySlider.minValue = m_MinValue;
            }
        }
        public float NormalizedValue
        {
            get => m_NormalizedValue;
            set
            {
                m_NormalizedValue = value;
                if(UnitySlider) UnitySlider.normalizedValue = m_NormalizedValue;
            }
        }
        /// <summary>
        /// 自由滑动还是仅整数
        /// </summary>
        public bool WholeNumber
        {
            get => m_wholeNumber;
            set
            {
                m_wholeNumber = value;
                if (UnitySlider) UnitySlider.wholeNumbers = m_wholeNumber;
            }
        }
        /// <summary>
        /// 当前值
        /// </summary>
        public float Value
        {
            get => m_Value;
            set 
            {
                m_Value = value;
                if (UnitySlider) 
                    UnitySlider.value = m_Value;
            }
        }
        /// <summary>
        /// 方向
        /// </summary>
        public UnityEngine.UI.Slider.Direction Direction = UnityEngine.UI.Slider.Direction.LeftToRight;
        /// <summary>
        /// 在值改变的时候调用
        /// </summary>
        public Action<float,Slider> OnValueChanged;

        /// <summary>
        /// 创建新的 Slider 对象
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            base.Create(active);

            if (BackgroundImage != null)
            {
                (BackgroundContainer = new Container()
                {
                    Name = "Background",
                    BackgroundType = BackgroundType,
                    BackgroundImage = BackgroundImage,
                }).SetParent(this);

                BackgroundContainer.RectTransform.sizeDelta = Vector2.zero;
                BackgroundContainer.RectTransform.anchorMin = Vector2.zero;
                BackgroundContainer.RectTransform.anchorMax = Vector2.one;

                BackgroundContainer.Get<LayoutElement>().ignoreLayout = true;
                Children.Add(BackgroundContainer);
            }

            var Slider = Get<UnityEngine.UI.Slider>();
            Slider.direction = Direction;
            Slider.maxValue = MaxValue;
            Slider.minValue = MinValue;
            Slider.normalizedValue = m_NormalizedValue;
            Slider.value = m_Value;
            Slider.wholeNumbers = m_wholeNumber;
            Slider.interactable = m_interactable;
            Slider.onValueChanged.AddListener(ValueChanged);

            if (FillAreaImage != null)
            {
                BoxModelGameObject fillArea = new BoxModelGameObject()
                {
                    Name = "Fill Area",
                    Group =
                    {
                        Padding = { 5 },
                        ControlChildHeight = false,
                    },
                    Children =
                    {
                        new Container()
                        {
                            Name = "Image",
                            BackgroundImage = FillAreaImage,
                            BackgroundType = FillAreaType
                        }
                    }
                };
                fillArea.SetParent(this);
                Slider.fillRect = fillArea.RectTransform;
                Slider.fillRect.sizeDelta = Vector2.zero;
            }

            ManagedGameObject i;
            (i = new BoxElementGameObject()
            {
                Name = "Handle Slide Area",
                Children =
                {
                    (Handle = new BoxPlainGameObject()
                    {
                        Name = "Handle",
                        Rect =
                        {
                            AnchorMax = Vector2.one,
                            AnchorMin = new Vector2(1, 0)
                        }
                    })
                }
            }).SetParent(this);
            if (SliderHandleImage != null)
            {
                Handle.Get<Image>().sprite = SliderHandleImage;
                Handle.Get<Image>().type = SliderHandleType;
                Slider.image = Handle.Get<Image>();
            }


            i.RectTransform.anchorMax = Vector2.one;
            i.RectTransform.sizeDelta = i.RectTransform.anchorMin = Vector2.zero;
            Slider.handleRect = Handle.RectTransform;
            
            UnitySlider = Slider;
        }

        /// <summary>
        /// 在值改变的时候调用
        /// </summary>
        /// <param name="value"></param>
        protected virtual void ValueChanged(float value)
        {
            OnValueChanged?.Invoke(value, this);
        }
    }
}
