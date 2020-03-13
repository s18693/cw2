using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    class OwnComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {

            return StringComparer.InvariantCultureIgnoreCase.Equals($"{x.fname} {x.lname} {x.indexNumber}", $"{y.fname} {y.lname} {y.indexNumber}");
            //throw new NotImplementedException();
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode($"{obj.fname} {obj.lname} {obj.indexNumber}");
            //throw new NotImplementedException();
        }
    }
}
