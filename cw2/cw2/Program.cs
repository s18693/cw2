using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

//using System.Xml;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create blanck log
            createLog();

            //Standart values
            string path = @"data.csv";
            string save = @"rezult";
            string format = "json";
            try
            {
                path = args[0];
            }
            catch (IndexOutOfRangeException)
            {
                Log("Use standart Path: " + path);
            }

            try
            {
                save = args[1];
            }
            catch (IndexOutOfRangeException)
            {
                Log("Use standart Save: " + save);
            }

            try
            {
                format = args[2];
            }
            catch (IndexOutOfRangeException)
            {
                Log("Use standart Format: " + format);
            }

            //read students
            var hash = new HashSet<Student>(new OwnComparer());
            try
            {
                using (var stream = new StreamReader(path))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] read = line.Split(',');

                        bool ok = true;
                        foreach (var tmp in read)
                            if (tmp.Equals(""))
                            {
                                Log("NULL value, student dismiss");
                                ok = false;
                            }
                        if (ok)
                            if (read.Length == 9)
                            {
                                var readStudies = new Studies { name = read[2], mode = read[3] };
                                var st = new Student { fname = read[0], lname = read[1], indexNumber = read[4], birthdate = read[5], email = read[6], mothersName = read[7], fathersName = read[8], studies = readStudies };
                                hash.Add(st);
                            }
                            else
                                Log("Not correct informations. Find: " + read.Length + " Need: 9");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Log("File not found");
            }
            //Counting
            Dictionary<string, int> activeStudnets = new Dictionary<string, int>();
            foreach (var s in hash)
            {
                if (!activeStudnets.ContainsKey(s.studies.name))
                    activeStudnets.Add(s.studies.name, 1);
                else
                    activeStudnets[s.studies.name]++;
            }

            //XML
            if (format.Equals("xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Student>), new XmlRootAttribute(@"uczelnia Created At " + DateTime.Now + new XmlRootAttribute("Author: Jan Kowalski")));
                FileStream writer = new FileStream(save + ".xml", FileMode.Create);
                serializer.Serialize(writer, hash);
            }
            //JSON
            if (format.Equals("json"))
            {
                University university = new University(hash, activeStudnets);

                var js = JsonConvert.SerializeObject(university, Formatting.Indented);
                File.WriteAllText(save + ".json", js);
            }
        }

        public static void createLog()
        {
            StreamWriter log = new StreamWriter(@"log.txt");
            log.Close();
        }
        public static void Log(string msg)
        {
            StreamWriter log = new StreamWriter(@"log.txt", append: true);
            log.WriteLine("[" + DateTime.Now + "] " + msg);
            log.Flush();
            log.Close();
        }
    }
}
