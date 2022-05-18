using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Template
{
    public partial class Service
    {
        private CodeGeneratorModel model;

        public Service(CodeGeneratorModel model)
        {
            this.model = model;
        }
    }
}
