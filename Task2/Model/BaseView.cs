using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Model
{
    public class BaseView<T> : Notifier 
    {
        public T View { get; set; }

        public BaseView(T view)
        {
            View = view;
        }
    }
}
