using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GravySoft.Razor.StringGenerator.NetFramework
{
    public class RazorViewToStringRenderer : IRazorViewToStringRenderer
    {
        private ControllerContext context;

        public RazorViewToStringRenderer()
        {
            context = CreateController().ControllerContext;
        }

        public Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model) => RenderViewToStringAsync(viewName, model, context);

        public Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model, ControllerContext context)
        {
            context.Controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindView(context, viewName, null);
                if (viewResult == null)
                    throw new FileNotFoundException($"View {viewName} could not be found");
                if (viewResult.View == null)
                    throw new FileNotFoundException($"View {viewName} could not be found. Searched locations:\r\n {string.Join("\r\n ", viewResult.SearchedLocations)}");

                var viewContext = new ViewContext(context, viewResult.View, context.Controller.ViewData, context.Controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(context, viewResult.View);
                return Task.FromResult(sw.GetStringBuilder().ToString());
            }
        }

        private static RendererController CreateController(RouteData routeData = null)
        {
            var controller = new RendererController();

            HttpContextBase wrapper;
            if (HttpContext.Current != null)
                wrapper = new HttpContextWrapper(System.Web.HttpContext.Current);
            else
                throw new InvalidOperationException("Can't create Controller Context if no active HttpContext instance is available.");

            if (routeData == null)
                routeData = new RouteData();

            // add the controller routing if not existing
            if (!routeData.Values.ContainsKey("controller") && !routeData.Values.ContainsKey("Controller"))
                routeData.Values.Add("controller", controller.GetType().Name.ToLower().Replace("controller", ""));

            controller.ControllerContext = new ControllerContext(wrapper, routeData, controller);
            return controller;
        }
    }
}
