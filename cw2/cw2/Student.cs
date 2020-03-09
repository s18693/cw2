using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    class Student
    {
        public int indexNumbe { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }

         public void WriteStudent()
        {
            Console.WriteLine(fname + " " + lname);
        }
    }
}
