using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using InitializeRoutesBase = Sitecore.Mvc.Pipelines.Loader.InitializeRoutes;

namespace Sitecore.Support.ExperienceForms.Mvc.Pipelines.Initialize
{
  public class InitializeRoutes : InitializeRoutesBase
  {
    protected override void RegisterRoutes(RouteCollection routes, PipelineArgs args)
    {
      routes.MapRoute("FormBuilder", "FormBuilder/{action}/{id}", new
      {
        controller = "FormBuilder",
        action = "Index",
        id = UrlParameter.Optional
      },
      new string[] { "Sitecore.Support.ExperienceForms.Mvc.Controllers" });

      routes.MapRoute("FieldTracking", "fieldtracking/{action}", new
      {
        controller = "FieldTracking",
        action = "Register"
      });
    }
  }
}