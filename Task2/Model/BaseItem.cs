using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task2.Model;

namespace Task2
{
    public class BaseItem : NotifyPropertyChanged, IParentItem
    {
        /// <summary>
        /// ///////////////////////
        /// </summary>
        private bool _treeViewChecked;

        public bool TreeViewChecked
        {
            get => _treeViewChecked;
            set
            {
                _treeViewChecked = value;
                OnPropertyChanged();
                OnTreeViewChecked();
            }
        }

        private void OnTreeViewChecked()
        {
            if(TreeViewChecked)
            {
                AllTextFile.list_io.Add(Name);
            }
            else
            {
                AllTextFile.list_io.RemoveAt(AllTextFile.list_io.FindIndex(line => line.StartsWith(Name)));
            }
        }
        /// <summary>
        /// ///////////////////////
        /// </summary>



        private string m_name = string.Empty;

        public string Name
        {
            get { return m_name; }
            set
            {
                m_name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        
        private IParentItem m_parent = null;

        public IParentItem Parent
        {
            get { return m_parent; }
            set
            {
                m_parent = value;
                OnPropertyChanged(nameof(Parent));
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
            if(item != null)
            {
                int indexOf = Children.IndexOf(item);
                if(indexOf > -1)
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
