using System.Threading.Tasks;

namespace GravySoft.Razor.StringGenerator
{
    /// <summary>  
    ///  Renders razor views to strings
    /// </summary>  
    public interface IRazorViewToStringRenderer
    {
        /// <summary>  
        ///  Generate a string from a view and model
        /// </summary>  
        /// <param name="viewName">Full path to the view, including a tilde and the file extension</param>
        /// <param name="model">Object to pass into the view as a model</param>
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
