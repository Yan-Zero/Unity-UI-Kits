using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityUIKit.Components;

namespace UnityUIKit.Core.GameObjects
{
    /// <summary>
    /// 没有任何对象，单纯手操 RectTransform 用的
    /// </summary>
    public class BoxPlainGameObject : ManagedGameObject
    {
        public BoxRect.ComponentAttributes Rect = new BoxRect.ComponentAttributes();

        public BoxRect BoxRect => Get<BoxRect>();
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            base.Create(active);

            BoxRect.Apply(Rect);
        }
    }
}
