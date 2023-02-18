using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Asp.Net_WebApi_projekt.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            try
            {
                object actualValue = Convert.ToDecimal(valueProviderResult.FirstValue, 
                    CultureInfo.InvariantCulture);
                bindingContext.Result = ModelBindingResult.Success(actualValue);
            }
            catch (FormatException e)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, e.Message);
            }

            return Task.CompletedTask;
        }
    }
}
