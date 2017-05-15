using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class QuestionAttribute : Attribute
    {
        public string Code { get; }
        public string Description { get; }
        public QuestionAttribute(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
