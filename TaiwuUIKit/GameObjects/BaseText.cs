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
using TMPro;

namespace TaiwuUIKit.GameObjects
{
    /// <summary>
    /// 文本显示
    /// </summary>
    public class BaseText : TMPLabel
    {
        /// <summary>
        /// 文本对齐方式
        /// </summary>
        public TextAlignmentOptions Alignment
        {
            get => _Text.Alignment;
            set
            {
                _Text.Alignment = value;
            }
        }

        /// <summary>
        /// 是否描边
        /// </summary>
        public bool UseOutline = true;
        /// <summary>
        /// 描边的颜色
        /// </summary>
        public Color OutlineColor = new Color(0, 0, 0, 1);

        /// <summary>
        /// 创建文本
        /// </summary>
        /// <param name="active">默认激活与否</param>
        public override void Create(bool active)
        {
            _Text.Font = Resources.Others.Font_GB2312;
            _Text.FontSize = 24;
            base.Create(active);

            if (UseOutline) Get<Outline>().effectColor = OutlineColor;
            Get<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }

        /// <summary>
        /// 应用配置
        /// </summary>
        public override void Apply()
        {
            base.Apply();
            if(Created)
            {
                if (!UseOutline)
                    Destroy(Get<Outline>());
                else
                    Get<Outline>().effectColor = OutlineColor;
            }
        }
    }
}
