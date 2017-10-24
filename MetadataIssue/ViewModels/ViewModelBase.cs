using MetadataIssue.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetadataIssue.ViewModels
{
    public class ViewModelBase : IViewModel
    {

        [MyValidation(ViewModelEnum.ViewModelBase)]
        public virtual string PropertyWithOverridableAttribute { get; set; }

    }
}
