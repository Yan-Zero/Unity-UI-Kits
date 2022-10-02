﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityUIKit.Core;
//using UnityUIKit.Core.GameObjects;
//using UnityUIKit.GameObjects;

//namespace TaiwuUIKit.GameObjects
//{
//    /// <summary>
//    /// 太吾标准风格的 Toggle
//    /// </summary>
//    public class TaiwuToggle : UnityUIKit.GameObjects.Toggle
//    {
//        // Load static background image
//        private static readonly PointerEnter _pointerEnter;
//        private static readonly PointerClick _pointerClick;
//        private static readonly ColorBlock _colors;
//        private static readonly Image _BackgroundImage;

//        public override Image Res_Image => _BackgroundImage;
//        public virtual PointerEnter Res_PointerEnter => _pointerEnter;
//        public virtual PointerClick Res_PointerClick => _pointerClick;
//        public override ColorBlock Res_Colors => _colors;

//        static TaiwuToggle()
//        {
//            var SetScreenToggle = Resources.Load<GameObject>("prefabs/ui/views/ui_systemsetting").transform.Find("SystemSetting/SetScreen/FullScreenToggle,702");
//            _pointerEnter = SetScreenToggle.GetComponent<PointerEnter>();
//            _pointerClick = SetScreenToggle.GetComponent<PointerClick>();
//            _BackgroundImage = SetScreenToggle.GetComponent<CToggle>().image;
//            _colors = new ColorBlock()
//            {
//                normalColor = new Color32(251,251,251,255),
//                highlightedColor = new Color32(245, 245, 245,255),
//                pressedColor = new Color32(142, 142, 142, 255),
//                disabledColor = new Color32(75, 75, 75, 255),
//                colorMultiplier = 1,
//                fadeDuration = 0.1f
//            };
//        }


//        private List<string> TipParm = new List<string>() { "", "" };
//        /// <summary>
//        /// Tip 的标题
//        /// </summary>
//        public string TipTitle
//        {
//            get => TipParm[0];
//            set
//            {
//                TipParm[0] = value;
//                if (Created) Get<MouseTipDisplayer>().param = TipParm.ToArray();
//            }
//        }
//        /// <summary>
//        /// Tip 的 内容，已废弃
//        /// 为了二进制兼容保留原接口
//        /// </summary>
//        [Obsolete("请使用 TipContent 来代替 TipContant", false)]
//        public string TipContant
//        {
//            get => TipParm[1];
//            set
//            {
//                TipParm[1] = value;
//                if (Created) Get<MouseTipDisplayer>().param = TipParm.ToArray();
//            }
//        }

//        /// <summary>
//        /// Tip 的 内容
//        /// </summary>
//        public string TipContent
//        {
//            get => TipParm[1];
//            set
//            {
//                TipParm[1] = value;
//                if (Created) Get<MouseTipDisplayer>().param = TipParm.ToArray();
//            }
//        }

//        /// <summary>
//        /// 文本表情（实际上是 BaseText 类型的）
//        /// </summary>
//        public override Label Label => m_Label;
//        private BaseText m_Label = new BaseText();

//        /// <summary>
//        /// 使用粗体
//        /// </summary>
//        public bool UseBoldFont
//        {
//            get
//            {
//                return (Label as BaseText).UseBoldFont;
//            }
//            set
//            {
//                (Label as BaseText).UseBoldFont = value;
//            }
//        }

//        /// <summary>
//        /// 使用 OutLine
//        /// </summary>
//        public bool UseOutline
//        {
//            get
//            {
//                return (Label as BaseText).UseOutline;
//            }
//            set
//            {
//                (Label as BaseText).UseOutline = value;
//            }
//        }

//        /// <summary>
//        /// 初始化
//        /// </summary>
//        public TaiwuToggle()
//        {
//            FontColor = Color.white;
//        }

//        /// <summary>
//        /// 创建组件
//        /// </summary>
//        /// <param name="active"></param>
//        public override void Create(bool active = true)
//        {
//            if(Element.PreferredSize.Count == 0)
//                Element.PreferredSize = PreferredSize;

//            base.Create(active);
//            UnityEngine.Object.Destroy(Label.Get<ContentSizeFitter>());
//            Label.Get<LayoutElement>().ignoreLayout = true;
//            Label.RectTransform.sizeDelta = Vector2.zero;
//            Label.RectTransform.anchoredPosition = Vector2.zero;
//            Label.RectTransform.anchorMin = Vector2.zero;
//            Label.RectTransform.anchorMax = Vector2.one;

//            if (!string.IsNullOrEmpty(TipTitle) || !string.IsNullOrEmpty(TipContant))
//                Get<MouseTipDisplayer>().param = TipParm.ToArray();

//            var Toggle = Get<UnityEngine.UI.Toggle>();
//            Toggle.transition = Selectable.Transition.ColorTint;
//            Toggle.colors = Res_Colors;

//            BoxModelGameObject BackgroundContainer;
//            (BackgroundContainer = new BoxModelGameObject()
//            {
//                Name = "Label"
//            }).SetParent(this);

//            var bgOn = BackgroundContainer.Get<Image>();
//            bgOn.type = Res_Image.type;
//            bgOn.sprite = Res_Image.sprite;
//            bgOn.color = new Color(156f / 255, 54f / 255, 54f / 255, 1);

//            BackgroundContainer.RectTransform.sizeDelta = Vector2.zero;
//            BackgroundContainer.RectTransform.anchorMin = Vector2.zero;
//            BackgroundContainer.RectTransform.anchorMax = Vector2.one;
//            BackgroundContainer.RectTransform.SetAsFirstSibling();

//            BackgroundContainer.Get<LayoutElement>().ignoreLayout = true;
//            Toggle.graphic = bgOn;

//            Get<Image>().color = new Color(50f / 255, 50f / 255, 50f / 255, 1);

//            if (Res_PointerClick != null)
//            {
//                var pc = Get<PointerClick>();
//                pc.playSE = Res_PointerClick.playSE;
//                pc.SEKey = Res_PointerClick.SEKey;
//            }
//            if (Res_PointerEnter != null)
//            {
//                PointerEnter pointerEnter = Get<PointerEnter>();
//                pointerEnter.changeSize = Res_PointerEnter.changeSize;
//                pointerEnter.restSize = Res_PointerEnter.restSize;
//                pointerEnter.xMirror = Res_PointerEnter.xMirror;
//                pointerEnter.yMirror = Res_PointerEnter.yMirror;
//                pointerEnter.move = Res_PointerEnter.move;
//                pointerEnter.moveX = Res_PointerEnter.moveX;
//                pointerEnter.moveSize = Res_PointerEnter.moveSize;
//                pointerEnter.restMoveSize = Res_PointerEnter.restMoveSize;
//                pointerEnter.SEKey = Res_PointerEnter.SEKey;
//                pointerEnter.changeTarget = Res_PointerEnter.changeTarget;
//            }
//        }
//    }
//}
