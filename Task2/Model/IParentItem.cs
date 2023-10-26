using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Model
{
    public interface IParentItem
    {
        void MoveTop(BaseItem item);

        void MoveUp(BaseItem item);

        void MoveDown(BaseItem item);

        void MoveBottom(BaseItem item);
    }
}
