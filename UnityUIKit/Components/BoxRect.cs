using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityUIKit.Core;

namespace UnityUIKit.Components
{
    public class BoxRect : ManagedComponent
    {
        public override void Apply(ManagedComponent.ComponentAttributes componentAttributes)
        {
            var attributes = componentAttributes as ComponentAttributes;
            if (!attributes) return;

            var rt = Get<RectTransform>();
            if (attributes.SizeDelta.HasValue)
                rt.sizeDelta = attributes.SizeDelta.Value;
            if (attributes.AnchorMin.HasValue)
                rt.anchorMin = attributes.AnchorMin.Value;
            if (attributes.AnchorMax.HasValue)
                rt.anchorMax = attributes.AnchorMax.Value;            
            if (attributes.AnchoredPosition.HasValue)
                rt.anchoredPosition = attributes.AnchoredPosition.Value;
            if (attributes.Pivot.HasValue)
                rt.pivot = attributes.Pivot.Value;
        }

        /// <summary>
        /// 组件属性
        /// </summary>
        public new class ComponentAttributes : ManagedComponent.ComponentAttributes
        {
            public Vector2? AnchorMin;
            public Vector2? AnchorMax;
            public Vector2? AnchoredPosition;
            /// <summary>
            /// 大小
            /// </summary>
            public Vector2? SizeDelta;
            /// <summary>
            /// 中心
            /// </summary>
            public Vector2? Pivot;
        }
    }
}
