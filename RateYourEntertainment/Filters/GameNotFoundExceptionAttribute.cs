using RateYourEntertainment.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RateYourEntertainment.Filters
{
    public class GameNotFoundExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            if (context.Exception is GameNotFoundException)
            {
                context.Result = new ViewResult
                {
                    ViewName = "GameNotFound",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = "An error occured while searching the requested game"
                    }
                };
            }
        }
    }
}