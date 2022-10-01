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

using UnityUIKit.Core.GameObjects;
using UnityEngine;
using UnityEngine.UI;
using UnityUIKit.Components;

namespace UnityUIKit.GameObjects
{
    public partial class Container
    {
        /// <summary>
        /// 会自动调整大小的
        /// </summary>
        public class FitterContainer : BoxAutoSizeModelGameObject
        {
            /// <summary>
            /// 背景图片
            /// </summary>
            public Sprite BackgroundImage = null;
            /// <summary>
            /// 背景颜色
            /// </summary>
            public Color? BackgroundColor = null;
            /// <summary>
            /// 背景图片类型
            /// </summary>
            public Image.Type BackgroundType = Image.Type.Simple;

            public Image Background => Get<Image>();

            public override void Create(bool active)
            {
                base.Create(active);

                if (BackgroundImage)
                {
                    Background.type = BackgroundType;
                    Background.sprite = BackgroundImage;
                }
                if (BackgroundColor.HasValue)
                    Background.color = BackgroundColor.Value;
            }
        }
    }
}
