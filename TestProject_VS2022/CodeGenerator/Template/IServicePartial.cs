using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Template
{
    public partial class IService
    {
        private CodeGeneratorModel model;

        public IService(CodeGeneratorModel model)
        {
            this.model = model;
        }
    }
}
