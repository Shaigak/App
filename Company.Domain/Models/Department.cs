using Company.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Models
{
    public class Department: BaseEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxSize { get; set; }

        public Employee Employee { get; set; }
    }
}
