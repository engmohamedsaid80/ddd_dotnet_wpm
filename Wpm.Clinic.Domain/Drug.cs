using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain
{
    public class Drug : Entity
    {
        public string Name { get; init; }
        public Drug(string name)
        {
            Name = name;
        }        
    }
}
