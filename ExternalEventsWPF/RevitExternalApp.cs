using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ExternalEventsWPF
{
    public class RevitExternalApp : IExternalApplication
    {
        //External application instance
        public static RevitExternalApp thisApp = null;

        //Form instance
        private ModelessWPF m_ModelessWPFForm;

        public Result OnShutdown(UIControlledApplication application)
        {
            if(m_ModelessWPFForm != null && m_ModelessWPFForm.Visibility == Visibility.Visible)
            {
                m_ModelessWPFForm.Close();
            }

            return Result.Succeeded;

        }

        public Result OnStartup(UIControlledApplication application)
        {
            m_ModelessWPFForm = null; //The command itself bring the form later on
            thisApp = this; //Static access must be given to reach the instance everywhere   

            //Create Ribbon Tab
            application.CreateRibbonTab("ModelessWPF");
            RibbonPanel panelHelper = application.CreateRibbonPanel("ModelessWPF", "ModelessWPF");

            string path = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonModelessWinForm = new PushButtonData("ModelessWinForm", "ModelessWinForm", path, "ExternalEventsWPF.RevitExternalCommand");
            BitmapImage iconModelessWinForm = new BitmapImage(new Uri("pack://application:,,,/ExternalEventsWPF;component/Assets/iconModelessForm.png"));
            PushButton pushButton_ModelessWinForm = panelHelper.AddItem(buttonModelessWinForm) as PushButton;
            pushButton_ModelessWinForm.LargeImage = iconModelessWinForm;

            return Result.Succeeded;

        }

        public void ShowModelessWinForm(UIApplication uiapp)
        {
            //If there is no UI instance yet, initialize and instance and show it
            if(m_ModelessWPFForm == null || PresentationSource.FromVisual(m_ModelessWPFForm) == null)
            {
                //Create a new event handler to handle the request that will be sent from UI (ExternalEvent.Raise())
                EventHandler handler = new EventHandler();

                //Initialize an External Event to pass it to the UI
                ExternalEvent exEvent = ExternalEvent.Create(handler);

                //Pass the instances to UI -- It is extremely important that UI is in charge of disposing these objects while closing
                m_ModelessWPFForm = new ModelessWPF(exEvent, handler);
                m_ModelessWPFForm.Show();
            }
        }


    }
}
