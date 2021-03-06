﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace cw2
{
    class Program_Kopia
    {
        //Podajemy 3 argumenty
        //Zrobić do końca piątku
        //hashSet zeby nie było duplikatów
        //jaison
        //IEnumerable -> ICollection -> Ilist
        //IEnumerable -> IQueryable INHERITANCE

        static void MainKopia(string[] args)
        {
            //var path = @"C:\Users\s18693\Desktop\dane.csv";
            var path = @"C:\Users\s18693\Desktop\dane.csv";

            var lines = File.ReadLines(path);
            /*
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            */
            var hash = new HashSet<Student>(new OwnComparer());
            //var compier = new OwnComparer();
            using (var stream = new StreamReader(path))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    var st = new Student { fname = student[0], lname = student[1] };
                    hash.Add(st);
                    //st.WriteStudent();
                }
            }

            foreach (var s in hash)
            {
               s.WriteStudent();
            }

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Student));
            var subReq = new Student();
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, hash);
                    xml = sww.ToString(); // Your XML
                }
            }

            var parsedDate = DateTime.Parse("9.03.2020");
            Console.WriteLine(parsedDate);
            var now = DateTime.UtcNow;
            Console.WriteLine(now);
            var today = DateTime.Today;
            Console.WriteLine(today);
            Console.WriteLine(today.ToShortDateString());



            /*
             .Netonsoft.JSON JSONConvert.SerializableObject();
             Student:{
             fuirstName: "Ala" 
             }
             [JSONProperty("created")]
             Utworzono()


             */



        }
    }
}
