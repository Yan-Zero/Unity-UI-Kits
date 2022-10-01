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

using System;
using UnityUIKit.Components;
using UnityUIKit.Core;

namespace UnityUIKit.GameObjects
{
    /// <summary>
    /// TMP 版的 Label
    /// </summary>
    public class TMPLabel : ManagedGameObject, IText
    {
        /// <summary>
        /// Text 的配置
        /// </summary>
        public TMPControl.ComponentAttributes _Text = new TMPControl.ComponentAttributes();

        /// <summary>
        /// 托管 TMP_Text
        /// </summary>
        public TMPControl TMPControl => Get<TMPControl>();

        /// <summary>
        /// 显示文本
        /// </summary>
        public string Text
        {
            get =>_Text.Content;
            set
            {
                _Text.Content = value;
                Apply();
            }
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="active">创建的是否是否为激活状态</param>
        public override void Create(bool active)
        {
            base.Create(active);

            TMPControl.Apply(_Text);
        }

        /// <summary>
        /// 应用 _Text 的配置
        /// </summary>
        public virtual void Apply()
        {
            if(Created)
                TMPControl.Apply(_Text);
        }
    }
}
