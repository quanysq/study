using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Template
{
    public partial class JSVue
    {
        private CodeGeneratorParameter model;

        public JSVue(CodeGeneratorParameter model)
        {
            this.model = model;
        }
    }
}
