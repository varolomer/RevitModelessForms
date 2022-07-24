using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExternalEventsWPF
{
    /// <summary>
    /// Interaction logic for ModelessWPF.xaml
    /// </summary>
    public partial class ModelessWPF : Window
    {
        private ExternalEvent m_ExEvent;
        private EventHandler m_Handler;

        public ModelessWPF(ExternalEvent exEvent, EventHandler handler)
        {
            InitializeComponent();

            m_ExEvent = exEvent;
            m_Handler = handler;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //Before the form is closed, everything must be disposed properly
            m_ExEvent.Dispose();
            m_ExEvent = null;
            m_Handler = null;

            //You have to call the base class
            base.OnClosing(e);
        }

        private void MakeRequest(RevitRequestId requestId)
        {
            m_Handler.RevitRequest.Make(requestId);
            m_ExEvent.Raise();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MakeRequest(RevitRequestId.CountWalls);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MakeRequest(RevitRequestId.CreateRandomWall);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            MakeRequest(RevitRequestId.BatchWalls);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            MakeRequest(RevitRequestId.ExportImage);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
