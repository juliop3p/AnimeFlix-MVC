using AnimeFlix.App.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.App.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews(o =>
            {
                string invalidValueMsg = "O valor preenchido é inválido para este campo.";
                string beNumericMsg = "O campo deve ser numérico.";
                string requiredValueMsg = "Este campo precisa ser preenchido.";
                string bodyRequiredMsg = "É necessário que o body na requisição não esteja vazio.";

                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => invalidValueMsg);
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => requiredValueMsg);
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => requiredValueMsg);
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => bodyRequiredMsg);
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => invalidValueMsg);
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => invalidValueMsg);
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => beNumericMsg);
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => invalidValueMsg);
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => invalidValueMsg);
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => beNumericMsg);
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => requiredValueMsg);

                o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services.AddRazorPages();

            return services;
        }
    }
}
