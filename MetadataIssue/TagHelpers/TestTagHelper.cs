using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MetadataIssue.Attributes;
using MetadataIssue.ViewModels;

namespace MetadataIssue.TagHelpers
{
    public class TestTagHelper : InputTagHelper
    {

        private readonly IModelMetadataProvider _modelMetadataProvider;

        public TestTagHelper(IHtmlGenerator generator, IModelMetadataProvider modelMetadataProvider) : base(generator)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var myValidationAttribute = this.For.Metadata.ValidatorMetadata.OfType<MyValidationAttribute>().SingleOrDefault();

            if(myValidationAttribute.ViewModelEnum == ViewModelEnum.ViewModelBase)
            {
                output.PostElement.AppendHtml($"<br /><span>Actual value : {myValidationAttribute.ViewModelEnum.ToString()}</span><br />");
            }

            if (typeof(IViewModel).IsAssignableFrom(this.For.Metadata.ContainerType))
            {
                var modelType = this.ViewContext.ViewData.ModelMetadata.ModelType;

                if (this.For.Metadata.ContainerType != modelType)
                {
                    var propertyMetadata = _modelMetadataProvider.GetMetadataForProperty(modelType, this.For.Name);
                    myValidationAttribute = propertyMetadata.ValidatorMetadata.OfType<MyValidationAttribute>().SingleOrDefault();
                }
            }

            if (myValidationAttribute.ViewModelEnum == ViewModelEnum.ChildViewModel)
            {
                output.PreElement.AppendHtml($"<br /><span>Expected value : {ViewModelEnum.ChildViewModel.ToString()}</span><br />");
            }

            output.TagName = "input";
            base.Process(context, output);
        }

    }
}
