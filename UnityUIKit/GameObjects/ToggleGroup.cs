﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityUIKit.Core;
using UnityUIKit.Core.GameObjects;

namespace UnityUIKit.GameObjects
{
	/// <summary>
	/// Toggle 组，仅有自动设置的功能
	/// </summary>
	public class ToggleGroup : BoxModelGameObject
	{
		public override void Create(bool active)
		{
			base.Create(active);
			foreach (ManagedGameObject child in Children)
			{
				if (child is Toggle)
					child.Get<UnityEngine.UI.Toggle>().group = Get<UnityEngine.UI.ToggleGroup>();
			}
		}
	}

}
