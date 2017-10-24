using MetadataIssue.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetadataIssue.ViewModels
{
    public class ChildViewModel : ViewModelBase
    {

        [MyValidation(ViewModelEnum.ChildViewModel)]
        public override string PropertyWithOverridableAttribute { get => base.PropertyWithOverridableAttribute; set => base.PropertyWithOverridableAttribute = value; }

    }
}
