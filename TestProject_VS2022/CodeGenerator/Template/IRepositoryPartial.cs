using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Template
{
    public partial class IRepository
    {
        private CodeGeneratorModel model;

        public IRepository(CodeGeneratorModel model)
        {
            this.model = model;
        }
    }
}
