using Sitecore.ExperienceForms.Mvc;
using Sitecore.ExperienceForms.Mvc.Constants;
using Sitecore.ExperienceForms.Mvc.Pipelines.GetModel;
using Sitecore.ExperienceForms.Mvc.Processing;
using Sitecore.Globalization;
using Sitecore.Mvc.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormBuilderControllerOrigin = Sitecore.ExperienceForms.Mvc.Controllers.FormBuilderController;
using PipelineNames = Sitecore.ExperienceForms.Mvc.Constants.PipelineNames;

namespace Sitecore.Support.ExperienceForms.Mvc.Controllers
{
  public class FormBuilderController : FormBuilderControllerOrigin
  {
    public FormBuilderController(IFormRenderingContext formRenderingContext, FormSubmitHandler formSubmitHandler)
      : base(formRenderingContext, formSubmitHandler)
    {
    }

    protected override ActionResult RenderForm(string id)
    {
      using (var getModelArgs = new GetModelEventArgs())
      {
        getModelArgs.ItemId = id;
        getModelArgs.TemplateId = TemplateIds.FormTemplateId;
        var result = PipelineService.Get().RunPipeline(PipelineNames.GetModel, getModelArgs, a => a);

        if (result.ViewModel == null)
        {
          return HttpNotFound(Translate.Text("Item Not Found"));
        }

        return PartialView(result.RenderingSettings.ViewPath, result.ViewModel);
      }
    }
  }
}