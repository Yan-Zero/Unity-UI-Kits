using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

        static Others()
        {
            var ab = AssetBundle.GetAllLoadedAssetBundles().First((i) => i.name == "fonts.uab");
            Font_GB2312 = ab.LoadAsset<TMPro.TMP_FontAsset>("Font SDF GB2312");
            ab = AssetBundle.GetAllLoadedAssetBundles().First((i) => i.name == "views.uab");
            var a = ab.LoadAsset<GameObject>("UI_SystemSetting").transform.transform.Find("MainWindow/Close");
        }
    }
}
