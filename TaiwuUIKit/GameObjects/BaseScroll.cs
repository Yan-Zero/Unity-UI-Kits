﻿// This file is part of the TaiwuTools <https://github.com/vizv/TaiwuTools/>.
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
using UnityUIKit.GameObjects;
using UnityEngine;
using UnityEngine.UI;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 滚动框，显然无滚动条
    /// </summary>
    public class BaseScroll : Container.ScrollContainer
    {
        /// <summary>
        /// 创建 BaseScroll 对象
        /// </summary>
        /// <param name="active"></param>
        public override void Create(bool active)
        {
            BackgroundImage = Resources.SpriteResource.SP_Kuang_6;
            BackgroundType = Image.Type.Sliced;

            //Group.Padding = new List<int>() { 10 };
            //Group.Spacing = 10;

            base.Create(active);
        }
    }
}
