using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetadataIssue.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MyValidationAttribute : ValidationAttribute
    {

        public MyValidationAttribute(ViewModelEnum viewModelEnum)
        {
            this.ViewModelEnum = viewModelEnum;
        }

        public ViewModelEnum ViewModelEnum { get; private set; }

    }
}
