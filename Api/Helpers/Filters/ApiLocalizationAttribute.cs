using System;
using KapersStore.Infrastructure.Helpers.LocalizationService;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Constants = KapersStore.Infrastructure.Helpers.Constants.Constants;

namespace Api.Helpers.Filters
{
    public class ApiLocalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue(Constants.LOCALIZATION_HEADER, out StringValues headerValue);

            if (headerValue.Count == 0 || !Enum.TryParse(headerValue.ToString().ToUpper(), out Locale locale))
                LocalizationState.Locale = Locale.RU;
            else
                LocalizationState.Locale = locale;
        }
    }
}
