using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.ExperienceForms.Mvc;
using System;
using System.Web.Helpers;

namespace Sitecore.Support.ExperienceForms.Mvc.Filters
{
  internal class ValidateFormRequestContext
  {
    internal virtual bool IsExperienceEditor
    {
      get
      {
        return Context.PageMode.IsExperienceEditor;
      }
    }

    internal virtual IFormRenderingContext FormRenderingContext
    {
      get
      {
        return ServiceProviderServiceExtensions.GetService<IFormRenderingContext>(ServiceLocator.ServiceProvider);
      }
    }

    internal virtual Action Validate
    {
      get
      {
        return new Action(AntiForgery.Validate);
      }
    }
  }
}