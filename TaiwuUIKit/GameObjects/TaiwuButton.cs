using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityUIKit.Core;
using UnityUIKit.Core.GameObjects;
using UnityUIKit.GameObjects;

namespace TaiwuUIKit.GameObjects
{
    /*
     * 怎么整呢，我们首先得把 Button 的 Image 给删掉，然后自己弄个 Text
     * 并且，按钮分三个部分：
     *  1. 父容器，其具有 CButton、PointerTrigger。
     *  2. Normal，显示正常的图片
     *  3. Hover，显示高亮图片
     *  4. Disabled，被禁用
    */

    /// <summary>
    /// 太吾的按钮
    /// </summary>
    public class TaiwuButton : UnityUIKit.GameObjects.Button
    {
        /// <summary>
        /// 文本
        /// </summary>
        private BaseText Label = new BaseText();

        public override void Create(bool active)
        {
            Group.Padding = new List<int>() { 10, 20 };
            if(BackgroundImage == null)
            {
                BackgroundType = Image.Type.Sliced;
            }

            base.Create(active);

            PointerTrigger pointerEnter = Get<PointerTrigger>();

        }
    }
}
