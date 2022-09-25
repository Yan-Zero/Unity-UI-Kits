using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;

namespace TaiwuUIKit.Resources
{
    /// <summary>
    /// 所有的 Sprite 资源
    /// </summary>
    public static class SpriteResource
    {
        /// <summary>
        /// 窗口的背景 Sprite
        /// </summary>
        public readonly static Sprite Background_Windows;
        /// <summary>
        /// 太吾内部的起名，用在了 Base Sroll
        /// </summary>
        public readonly static Sprite SP_Kuang_6;
        /// <summary>
        /// 太吾内部的命名，用在了 Base Frame
        /// </summary>
        public readonly static Sprite SP_Kuang_7;
        /// <summary>
        /// sp_biaoti_dabiaoti_2，TaiwuTitle
        /// </summary>
        public readonly static Sprite SP_Title_Big_2;
        /// <summary>
        /// 按钮，Normal
        /// </summary>
        public readonly static Sprite SP_Button_2_0;
        /// <summary>
        /// 按钮，高亮状态。
        /// </summary>
        public readonly static Sprite SP_Button_2_1;



        static SpriteResource()
        {
            var ab = AssetBundle.GetAllLoadedAssetBundles().First((i) => i.name == "ui_texture_mainmenu.uab");
            var image = ab.LoadAsset<Texture2D>("mainmenu_di_1");
            Background_Windows = Sprite.Create(image, new Rect(0,0, image.width, image.height), new Vector2(0.5f,0.5f), 100f, 0u, SpriteMeshType.Tight, new Vector4(215, 131, 215, 112));
            
            var sa = AssetBundle.GetAllLoadedAssetBundles().First((i) => i.name == "atlas_common.uab").LoadAsset<SpriteAtlas>("Common");
            SP_Kuang_6 = sa.GetSprite("sp_kuang_6");
            SP_Kuang_7 = sa.GetSprite("sp_kuang_7");
            SP_Title_Big_2 = sa.GetSprite("sp_biaoti_dabiaoti_1");
            SP_Button_2_0 = sa.GetSprite("sp_anniu_2_0");
            SP_Button_2_1 = sa.GetSprite("sp_anniu_2_1");
        }
    }
}
