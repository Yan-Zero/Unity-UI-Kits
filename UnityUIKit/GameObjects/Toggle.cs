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
	/// 开关
	/// </summary>
	public class Toggle : BaseTogleButton
	{
		/// <summary>
		/// 更改值时候调用
		/// </summary>
		public Action<bool, Toggle> onValueChanged = delegate {} ;
		/// <summary>
		/// 是否选中
		/// </summary>
		public bool IsOn
		{
			get => m_isOn;

            set
			{
				m_isOn = value;
				if (Created)
					Get<UnityEngine.UI.Toggle>().isOn = m_isOn;
			}
		}
		private bool m_isOn = false;
        /// <summary>
        /// 交互性
        /// </summary>
        public override bool Interactable
        {
            get => m_interactable;
            set
            {
                m_interactable = value;
                if (Created) Get<UnityEngine.UI.Toggle>().interactable = m_interactable;
            }
        }
        /// <summary>
        /// 预设大小
        /// </summary>
        public List<float> PreferredSize = new List<float> { 0, 50 };

		/// <summary>
		/// 创建 Toggle 对象
		/// </summary>
		/// <param name="active"></param>
		public override void Create(bool active)
		{
			if (Element.PreferredSize.Count == 0)
				Element.PreferredSize = PreferredSize;

			base.Create(active);
			
			UnityEngine.UI.Toggle toggle = Get<UnityEngine.UI.Toggle>();
			toggle.isOn = m_isOn;
			toggle.image = Children.Find((x) => x.Name == "Image").Get<Image>();
            toggle.onValueChanged.AddListener(OnValueChanged_Invoke);
		}

		/// <summary>
		/// 显然，是为了让子类重写的
		/// </summary>
		/// <param name="isOn"></param>
		protected virtual void OnValueChanged_Invoke(bool isOn)
		{
			onValueChanged?.Invoke(isOn, this);
		}
	}

}
