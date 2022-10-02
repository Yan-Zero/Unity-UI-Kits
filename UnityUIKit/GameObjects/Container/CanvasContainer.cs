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

using UnityEngine;
using UnityEngine.UI;
using UnityUIKit.Core;

namespace UnityUIKit.GameObjects
{
    
    public partial class Container
    {
        public class CanvasContainer : Container
        {
            public Canvas Canvas => Get<Canvas>();

            public override void Create(bool active)
            {
                base.Create(active);

                Get<GraphicRaycaster>();

                Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }
        }
    }
}
