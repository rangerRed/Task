#pragma warning disable CS8625
using System.Collections.ObjectModel;

namespace Task2.Model
{
    public class MainView : BaseView<MainWindow>, IParentItem
    {
        public MainView(MainWindow view) : base(view) { }

        private BaseItem m_selectedItem = null;

        public BaseItem SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private ObservableCollection<BaseItem> m_children = new ObservableCollection<BaseItem>();

        public ObservableCollection<BaseItem> Children
        {
            get { return m_children; }
            set
            {
                m_children = value;
                OnPropertyChanged(nameof(Children));
            }
        }

        public void MoveTop(BaseItem item)
        {
            if (item != null)
            {
                int indexOf = Children.IndexOf(item);
                if (indexOf > -1)
                {
                    Children.RemoveAt(indexOf);
                    Children.Insert(0, item);
                }
            }
        }

        public void MoveUp(BaseItem item)
        {
            if (item != null)
            {
                int indexOf = Children.IndexOf(item);
                if (indexOf > 0)
                {
                    int indexOf2 = indexOf - 1;
                    BaseItem item2 = Children[indexOf2];
                    Children[indexOf] = item2;
                    Children[indexOf2] = item;
                }
            }
        }

        public void MoveDown(BaseItem item)
        {
            if (item != null)
            {
                int indexOf = Children.IndexOf(item);
                if (indexOf < Children.Count - 1 && indexOf > -1)
                {
                    int indexOf2 = indexOf + 1;
                    BaseItem item2 = Children[indexOf2];
                    Children[indexOf] = item2;
                    Children[indexOf2] = item;
                }
            }
        }

        public void MoveBottom(BaseItem item)
        {
            if (item != null)
            {
                int indexOf = Children.IndexOf(item);
                if (indexOf > -1)
                {
                    Children.RemoveAt(indexOf);
                    Children.Add(item);
                }
            }
        }

    }
}
