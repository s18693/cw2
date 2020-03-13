using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    [Serializable]
    public class University
    {

        [JsonProperty("Student: ")] HashSet<Student> students;

        [JsonProperty("Active Studies: ")] public Dictionary<string, int> activeStudnets;

        public University(HashSet<Student> students, Dictionary<string, int> activeStudnets)
        {
            this.students = students;
            this.activeStudnets = activeStudnets;
        }
    }
}
