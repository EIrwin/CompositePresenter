using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompositePresenter
{
    /// <summary>
    /// Interaction logic for Toolbox.xaml
    /// </summary>
    public partial class Toolbox : UserControl
    {
        public Toolbox()
        {
            InitializeComponent();
        }

        private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem listBoxItem = sender as ListBoxItem;

            if (listBoxItem != null)
            {
                DragDrop.DoDragDrop(listBoxItem, listBoxItem.Content.ToString(), DragDropEffects.All);
            }
        }
    }
}
