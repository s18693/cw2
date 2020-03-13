using System;
using Newtonsoft.Json;

namespace cw2
{
    [Serializable]
   public class Student
    {
        [JsonProperty("indexNumber")]
        public string indexNumber { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Studies studies { get; set; }

         public void WriteStudent()
        {
            Console.WriteLine(fname + " " + lname);
        }
    }
}
