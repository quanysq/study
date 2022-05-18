using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Template
{
    public partial class Repository
    {
        private CodeGeneratorModel model;

        public Repository(CodeGeneratorModel model)
        {
            this.model = model;
        }
    }
}
