using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace ExternalEventsWPF
{
    public class EventHandler : IExternalEventHandler
    {
        // The value of the latest request made by the modeless form 
        private RevitRequest m_request = new RevitRequest();

        /// <summary>
        /// A public property to access the current request value
        /// </summary>
        public RevitRequest RevitRequest
        {
            get { return m_request; }
        }

        public void Execute(UIApplication uiapp)
        {
            switch(RevitRequest.Take())
            {
                case RevitRequestId.None:
                    {
                        return;
                    }
                case RevitRequestId.CountWalls:
                    {
                        Commands.CountWalls(uiapp);
                        break;
                    }
                case RevitRequestId.CreateRandomWall:
                    {
                        Commands.CreateRandomWalls(uiapp);
                        break;
                    }
                case RevitRequestId.BatchWalls:
                    {
                        Commands.BatchWalls(uiapp);
                        break;
                    }
                case RevitRequestId.ExportImage:
                    {
                        Commands.ExportImage(uiapp);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public string GetName()
        {
            return "Basic External EventHandler";
        }
    }
}
