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

using System.Collections.Generic;
using UnityUIKit.Core;
using UnityUIKit.GameObjects;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 基本框架
    /// </summary>
    public class BaseFrame : Container
    {
        /// <summary>
        /// 元素的排列方向
        /// </summary>
        public Direction Direction = Direction.Horizontal;

        /// <summary>
        /// 间隔
        /// </summary>
        public float Spacing = 20;
        /// <summary>
        /// 上下左右 or
        /// 上下 左右 or
        /// 上 左右 下 or
        /// 上 右 下 左 
        /// </summary>
        public List<int> Padding = new List<int>() { 20 };
        /// <summary>
        /// 创建 BaseFrame 对象
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            if (BackgroundImage == null)
            {
                BackgroundImage = Resources.SpriteResource.SP_Kuang_7;
                BackgroundType = Image.Type.Sliced;
            }

            // Default padding
            Group.Direction = Direction;
            Group.Padding = Padding;
            Group.Spacing = Spacing;

            base.Create(active);
        }
    }
}
