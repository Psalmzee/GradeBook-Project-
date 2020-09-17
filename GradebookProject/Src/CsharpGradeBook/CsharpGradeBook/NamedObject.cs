using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class NamedObject //Represents the base class to be inherited by another class
        
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
            {
                get;
                set;
            }
        
    }
}
