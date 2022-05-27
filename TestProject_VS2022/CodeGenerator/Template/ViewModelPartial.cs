using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Template
{
    public partial class ViewModel
    {
        private CodeGeneratorParameter model;

        public ViewModel(CodeGeneratorParameter model)
        {
            this.model = model;
        }
    }
}
