using Sitecore.Diagnostics;
using System;
using System.Web.Mvc;

namespace Sitecore.Support.ExperienceForms.Mvc.Filters
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
  internal class ValidateFormRequestAttribute : FilterAttribute, IAuthorizationFilter
  {
    private readonly ValidateFormRequestContext _validationContext;

    public ValidateFormRequestAttribute() : this(new ValidateFormRequestContext())
    {
    }

    internal ValidateFormRequestAttribute(ValidateFormRequestContext validateFormAntiForgeryContext)
    {
      Assert.ArgumentNotNull(validateFormAntiForgeryContext, "validateFormAntiForgeryContext");
      this._validationContext = validateFormAntiForgeryContext;
    }

    public void OnAuthorization(AuthorizationContext filterContext)
    {
      Assert.ArgumentNotNull(filterContext, "filterContext");
      string str = this._validationContext.FormRenderingContext.CreatePropertyName("FormItemId");
      if (!string.IsNullOrEmpty(filterContext.RequestContext.HttpContext.Request.Form[str]) || !this._validationContext.IsExperienceEditor)
      {
        this._validationContext.Validate();
      }
    }
  }
}