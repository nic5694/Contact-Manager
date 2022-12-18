using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB.Entities
{
    internal class Type
    {
        public char Code { get; set; }
        public string Description { get; set; }

        public Type(char code, string description)
        {
            Code = code;
            Description = description;
        }
        public Type() { }
    }
}
