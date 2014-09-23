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
using CompositePresenter.Core;

namespace CompositePresenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TempBootstrap();
        }

        /// <summary>
        /// The following is only a temporary method to house code
        /// that we cannot 'mock' or reproduce that lives inside the
        /// actual code base in PortLogic
        /// </summary>
        public void TempBootstrap()
        {

            EventBus eventBus = new EventBus();

            Canvas canvas = new Canvas();

            IParameter designerParameter = new DesignerParameter()
                {
                    Canvas = canvas
                };

            Presenter<IDesignerView> designerPresenter = new DesignerPresenter(eventBus,designerParameter);
            IView view = designerPresenter.Present();
            this.MainPanel.Children.Add((UIElement)view);

            //What do we do with the managers? -> See Confluence Questions
            DesignerManager designerManager = new DesignerManager(eventBus);

        }
    }
}
