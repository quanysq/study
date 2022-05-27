using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Template
{
    public partial class JSController
    {
        private CodeGeneratorParameter model;

        public JSController(CodeGeneratorParameter model)
        {
            this.model = model;
        }
    }
}
