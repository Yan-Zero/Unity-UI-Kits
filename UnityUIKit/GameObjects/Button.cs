using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityUIKit.Core;

namespace UnityUIKit.GameObjects
{
	/// <summary>
	/// 按钮
	/// </summary>
	public class Button : BaseTogleButton
	{
		/// <summary>
		/// 点击的回调函数
		/// </summary>
		public Action<Button> OnClick;

		/// <summary>
		/// 为了方便后人（类）罢了。
		/// </summary>
		protected virtual void OnClick_Invoke()
		{
			OnClick?.Invoke(this);
		}

		/// <summary>
		/// Unity 的 Button 类，懒得写个 Component 了
		/// </summary>
		public UnityEngine.UI.Button UnityButton;

		/// <summary>
		/// 交互性
		/// </summary>
		public override bool Interactable
		{
			get => m_interactable;
			set
			{
				m_interactable = value;
				if (UnityButton) UnityButton.interactable = m_interactable;
			}
		}

		/// <summary>
		/// 创建按钮对象
		/// </summary>
		/// <param name="active"></param>
		public override void Create(bool active)
		{
            base.Create(active);

			UnityButton = Get<UnityEngine.UI.Button>();
			UnityButton.onClick.AddListener(OnClick_Invoke);
			UnityButton.image = Children.Find((x)=> x.Name == "Image")?.Get<Image>();
			UnityButton.interactable = m_interactable;
		}
	}
}
