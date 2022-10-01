using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaiwuUIKit.GameObjects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TaiwuUIKit.Resources
{
    /// <summary>
    /// 所有的 Sprite 资源
    /// </summary>
    public static class Others
    {
        /// <summary>
        /// 窗口的背景 Sprite
        /// </summary>
        public readonly static TMPro.TMP_FontAsset Font_GB2312;
        /// <summary>
        /// 滑条的颜色变化
        /// </summary>
        public readonly static ColorBlock SliderColorBlocks;

        static Others()
        {
            var ab = AssetBundle.GetAllLoadedAssetBundles().First((i) => i.name == "fonts.uab");
            Font_GB2312 = ab.LoadAsset<TMPro.TMP_FontAsset>("Font SDF GB2312");

            SliderColorBlocks = new ColorBlock()
            {
                normalColor = new Color(1f, 1f, 1f, 1f),
                highlightedColor = new Color(0.9608f, 0.9608f, 0.9608f, 1f),
                pressedColor = new Color(0.7843f, 0.7843f, 0.7843f, 1f),
                disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
                fadeDuration = 0.1f,
            };
        }

        /// <summary>
        /// 太吾音乐
        /// </summary>
        internal interface ITaiwuSound
        {
            /// <summary>
            /// Audio Key
            /// </summary>
            string LeftClick_AudioKey
            {
                get;
            }
        }
        internal class PClick : MonoBehaviour, IPointerClickHandler
        {
            public ITaiwuSound _Parent = null;
            public void OnPointerClick(PointerEventData eventData)
            {
                switch(eventData.button)
                {
                    case PointerEventData.InputButton.Left:
                        if (!string.IsNullOrEmpty(_Parent?.LeftClick_AudioKey))
                            AudioManager.Instance.PlaySound(_Parent.LeftClick_AudioKey);
                        else
                            AudioManager.Instance.PlaySound("ui_default_click_left");
                        break;
                }
            }
        };

#if DEBUG
        /// <summary>
        /// 一言难尽的玩意，用来给 dnSpy 捕获调用的
        /// </summary>
        public static void test()
        {
            System.Threading.Thread.Sleep(1000);
        }
#endif
    }
}
