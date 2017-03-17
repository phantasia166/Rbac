using Rbac.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Model
{
    public abstract class RbacModelBase: IRbacModel
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public RbacModelBase(string name)
        {
            Name = name;
        }
    }
}
