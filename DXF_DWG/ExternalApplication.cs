using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Windows.Forms;


namespace DXF_DWG
{
    class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {

            Application.SetCompatibleTextRenderingDefault(false);

            application.CreateRibbonTab("CAD to Revit");

            string path = Assembly.GetExecutingAssembly().Location;

            PushButtonData button = new PushButtonData("Button1", "Convert", path, "DXF_DWG.Project");

            RibbonPanel panel = application.CreateRibbonPanel("CAD to Revit", "Commands");

            PushButton pushButton = panel.AddItem(button) as PushButton ;

            Uri image_path = new Uri(@"C:\Users\Khalid\Desktop\Revit API Project\Code\Revit_API\DXF_DWG\icon.png");

            BitmapImage image = new BitmapImage(image_path);

            pushButton.LargeImage = image;

            return Result.Succeeded;
        }
    }
}
