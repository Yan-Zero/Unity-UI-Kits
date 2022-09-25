using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityUIKit.Components;

namespace UnityUIKit.Core.GameObjects
{
    public class BoxGridGameObject : BoxSizeFitterGameObject
    {
        public BoxGrid.ComponentAttributes Grid = new BoxGrid.ComponentAttributes();

        public BoxGrid BoxGrid => Get<BoxGrid>();

        public override void Create(bool active)
        {
            base.Create(active);

            BoxGrid.Apply(Grid);
            //BoxElement.Apply(Element);
        }
    }
}
