// This file is part of the TaiwuTools <https://github.com/vizv/TaiwuTools/>.
// Copyright (C) 2020  Taiwu Modding Community Members
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using UnityUIKit.Core;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace UnityUIKit.Components
{
    /// <summary>
    /// Text 类的接口
    /// </summary>
    public interface IText
    {
        /// <summary>
        /// Text 的属性接口
        /// </summary>
        string Text
        {
            get;
            set;
        }

        /// <summary>
        /// 单纯为了兼容罢了
        /// </summary>
        /// <param name="managedGameObject"></param>
        /// <param name="worldPositionStays"></param>
        void SetParent(ManagedGameObject managedGameObject, bool worldPositionStays = false);
        /// <summary>
        /// 为了兼容
        /// </summary>
        /// <param name="active"></param>
        void Create(bool active);
        /// <summary>
        /// 虽然没用上，但是还是兼容（
        /// </summary>
        string Name
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 托管 Text
    /// </summary>
    public class TextControl : ManagedComponent
    {
        public Text Text => Get<Text>();

        public override void Apply(ManagedComponent.ComponentAttributes componentAttributes)
        {
            var attributes = componentAttributes as ComponentAttributes;
            if (!attributes) return;

            Text.fontStyle = attributes.FontStyle;
            Text.font = attributes.Font;
            Text.fontSize = attributes.FontSize;
            Text.color = attributes.Color;
            Text.alignment = attributes.Alignment;
            Text.text = attributes.Content;
            Text.horizontalOverflow = HorizontalWrapMode.Overflow;
        }


        public new class ComponentAttributes : ManagedComponent.ComponentAttributes
        {
            public Font Font = null;
            public int FontSize = 18;
            public Color Color = Color.white;
            public TextAnchor Alignment = TextAnchor.MiddleCenter;
            public string Content = null;
            public FontStyle FontStyle = FontStyle.Normal;
        }
    }

    /// <summary>
    /// Text Control 的 TMP_Text 版
    /// </summary>
    public class TMPControl : ManagedComponent
    {
        /// <summary>
        /// 组件本身
        /// </summary>
        public TextMeshProUGUI Text => Get<TextMeshProUGUI>();

        /// <summary>
        /// 应用配置
        /// </summary>
        /// <param name="componentAttributes">Attributes，配置</param>
        public override void Apply(ManagedComponent.ComponentAttributes componentAttributes)
        {
            var attributes = componentAttributes as ComponentAttributes;
            if (!attributes) return;

            Text.fontStyle = attributes.FontStyle;
            Text.font = attributes.Font;
            Text.fontSize = attributes.FontSize;
            Text.color = attributes.Color;
            Text.alignment = attributes.Alignment;
            Text.text = attributes.Content;
            Text.overflowMode = attributes.OverflowModes;
        }

        /// <summary>
        /// Attributes
        /// </summary>
        public new class ComponentAttributes : ManagedComponent.ComponentAttributes
        {
            public TMP_FontAsset Font = null;
            public int FontSize = 18;
            public Color Color = Color.white;
            public TextAlignmentOptions Alignment = TextAlignmentOptions.Center;
            public string Content = null;
            public FontStyles FontStyle = FontStyles.Normal;
            public TextOverflowModes OverflowModes = TextOverflowModes.Overflow;
        }
    }
}
