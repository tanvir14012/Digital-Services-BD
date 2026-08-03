using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Digital_Services_BD.Services
{
    public class ConvertRazorToString
    {
        public static string RenderRazorViewToString(Controller controller, ICompositeViewEngine viewEngine, string viewName, object model)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View,
                                             controller.ViewData, controller.TempData, sw, new HtmlHelperOptions());
                var task = viewResult.View.RenderAsync(viewContext);
                task.Wait();
                return sw.GetStringBuilder().ToString();
            }
        }
    }

}
