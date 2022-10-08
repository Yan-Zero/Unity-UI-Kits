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
        public readonly static Sprite WindowsBG;
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
        /// <summary>
        /// mainmenu_heidi，黑底。
        /// </summary>
        public readonly static Sprite Black_BGound;
        /// <summary>
        /// 灰色的 No，sp_popup_window_18
        /// </summary>
        public readonly static Sprite No_Disable;
        /// <summary>
        /// 黄色的 No，sp_popup_window_9
        /// </summary>
        public readonly static Sprite No_Normal;
        /// <summary>
        /// 高亮的◇按钮，sp_popup_window_6_1
        /// </summary>
        public readonly static Sprite Rhombus_Hover;
        /// <summary>
        /// 普通的◇按钮，sp_popup_window_6_0
        /// </summary>
        public readonly static Sprite Rhombus_Normal;
        /// <summary>
        /// Toggle不亮 sp_newgame_anniu_2_0
        /// </summary>
        public readonly static Sprite Toggle_Normal_OLD;
        /// <summary>
        /// Toggle高亮，sp_newgame_anniu_2_1
        /// </summary>
        public readonly static Sprite Toggle_Hover_OLD;
        /// <summary>
        /// Toggle不亮 sp_anniu_14_0
        /// </summary>
        public readonly static Sprite Toggle_Off;
        /// <summary>
        /// Toggle高亮 sp_anniu_14_1
        /// </summary>
        public readonly static Sprite Toggle_Hover;
        /// <summary>
        /// Toggle选中 sp_anniu_14_2
        /// </summary>
        public readonly static Sprite Toggle_On;
        /// <summary>
        /// Toggle 的右上角，亮，sp_newgame_anniu_3_0
        /// </summary>
        public readonly static Sprite TPatch_Hover;
        /// <summary>
        /// Toggle 的右上角，不亮，sp_newgame_anniu_3_1
        /// </summary>
        public readonly static Sprite TPatch_Normal;
        /// <summary>
        /// 上边的小黑点，sp_huadongtiao_0_1
        /// </summary>
        public readonly static Sprite SliderDot;
        /// <summary>
        /// 滑动条背景，sp_huadongtiao_0_0
        /// </summary>
        public readonly static Sprite SliderBG;
        /// <summary>
        /// 滑动条的滑块，sp_huadongtiao_1_0
        /// </summary>
        public readonly static Sprite SliderHandle_Normal;
        /// <summary>
        /// 高亮
        /// </summary>
        public readonly static Sprite SliderHandle_Hover;
        /// <summary>
        /// 禁用
        /// </summary>
        public readonly static Sprite SliderHandle_Disabled;

        static SpriteResource()
        {
            var ab = AssetBundle.GetAllLoadedAssetBundles().First((i) => i.name == "ui_texture_mainmenu.uab");
            var image = ab.LoadAsset<Texture2D>("mainmenu_di_1");
            WindowsBG = Sprite.Create(image, new Rect(0,0, image.width, image.height), new Vector2(0.5f,0.5f), 100f, 0u, SpriteMeshType.Tight, new Vector4(215, 131, 215, 112));
            
            var sa = AssetBundle.GetAllLoadedAssetBundles().First((i) => i.name == "atlas_common.uab").LoadAsset<SpriteAtlas>("Common");
            SP_Kuang_6 = sa.GetSprite("sp_kuang_6");
            SP_Kuang_7 = sa.GetSprite("sp_kuang_7");
            SP_Title_Big_2 = sa.GetSprite("sp_biaoti_dabiaoti_1");

            No_Normal = sa.GetSprite("sp_popup_window_9");
            No_Disable = sa.GetSprite("sp_popup_window_18");
            Rhombus_Normal = sa.GetSprite("sp_popup_window_6_0");
            Rhombus_Hover = sa.GetSprite("sp_popup_window_6_1");

            Toggle_Normal_OLD = sa.GetSprite("sp_newgame_anniu_2_0");
            Toggle_Hover_OLD = sa.GetSprite("sp_newgame_anniu_2_1");
            TPatch_Hover = sa.GetSprite("sp_newgame_anniu_3_0");
            TPatch_Normal = sa.GetSprite("sp_newgame_anniu_3_1");
            Toggle_Off = sa.GetSprite("sp_anniu_14_0");
            Toggle_Hover = sa.GetSprite("sp_anniu_14_1");
            Toggle_On = sa.GetSprite("sp_anniu_14_2");

            SliderDot = sa.GetSprite("sp_huadongtiao_0_1");
            SliderBG = sa.GetSprite("sp_huadongtiao_0_0");
            SliderHandle_Normal = sa.GetSprite("sp_huadongtiao_1_0");
            SliderHandle_Disabled = sa.GetSprite("sp_huadongtiao_1_0");
            SliderHandle_Hover = sa.GetSprite("sp_huadongtiao_1_1");

            SP_Button_2_0 = sa.GetSprite("sp_anniu_2_0");
            SP_Button_2_0 = Sprite.Create(SP_Button_2_0.texture,
                SP_Button_2_0.textureRect, new Vector2(0.5f, 0.5f), 100f,
                0u, SpriteMeshType.Tight, new Vector4(60, 20, 60, 20));
            SP_Button_2_1 = sa.GetSprite("sp_anniu_2_1");
            SP_Button_2_1 = Sprite.Create(SP_Button_2_1.texture,
                SP_Button_2_1.textureRect, new Vector2(0.5f, 0.5f), 100f,
                0u, SpriteMeshType.Tight, new Vector4(60, 20, 60, 20));

            sa = AssetBundle.GetAllLoadedAssetBundles().First((i) => i.name == "atlas_remaketmp_mainmenu.uab").LoadAsset<SpriteAtlas>("remaketmp_mainmenu.spriteatlas");
            Black_BGound = sa.GetSprite("mainmenu_heidi");
        }
    }
}
