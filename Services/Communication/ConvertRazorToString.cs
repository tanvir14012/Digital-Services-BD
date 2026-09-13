using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Digital_Services_BD.Services;

public static class ConvertRazorToString
{
    public static async Task<string> RenderRazorViewToStringAsync(Controller controller, ICompositeViewEngine viewEngine, string viewName, object? model)
    {
        using var writer = new StringWriter();
        var result = viewEngine.FindView(controller.ControllerContext, viewName, false);
        if (!result.Success) throw new InvalidOperationException($"View '{viewName}' was not found.");
        var viewData = new ViewDataDictionary(controller.ViewData) { Model = model };
        var context = new ViewContext(controller.ControllerContext, result.View, viewData, controller.TempData, writer, new HtmlHelperOptions());
        await result.View.RenderAsync(context);
        return writer.ToString();
    }
}
