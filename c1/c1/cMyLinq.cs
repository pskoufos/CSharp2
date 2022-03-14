using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c1
{
       static  class myLinq
    {

         struct Student
        {
            public int StudentID;
            public string StudentName;
            public int StudentAge;

            public Student(int studentID, string studentName, int studentAge)
            {
                StudentID = studentID;
                StudentName = studentName;
                StudentAge = studentAge;
            }

            public override string ToString()
            {
                string result = string.Empty; 

                result = String.Concat(StudentID, '\t', StudentName, '\t', StudentAge);
                return result; 
            }
        }

        internal class Ocupation
        {
            public Ocupation()
            {
            }

            public Ocupation(int studentID, string ocuDescr)
            {
                this.StudentID = studentID;
                this.OcuDescr = ocuDescr;
            }

            public int StudentID { get; set; }
            public string OcuDescr { get; set; }
        }


        internal class Join1Results
        {
            public int StudentID { get; set; }   
            public string StudentName { get; set; }
            public int StudentAge { get; set; }
            public string StudentOcupation { get; set; }

            public override string ToString()
            {
                string result = string.Empty;

                result = String.Concat(StudentID, '\t', StudentName, '\t', StudentAge , '\t' , StudentOcupation);
                return result;
            }
        }



        public static void queryStores ()
        {
            Student[] students = new Student[]{
                new Student(1, "John", 18 ),
                new Student{StudentID= 2, StudentName = "Steve", StudentAge =  21 },
                new Student(3, "Bill", 25 ),
                new Student(4, "Ram" , 20 ),
                new Student(5, "Ron" , 31 ),
                new Student(6, "Nikos" , 31 ),
                new Student(7, "Chris",17 ),
                new Student(8, "Rob",19  )
            };

            Ocupation[] ocupation = new Ocupation[]{
                new Ocupation(){StudentID= 1, OcuDescr="Taverniaris"} ,
                new Ocupation(2, "Fournaris"),
                new Ocupation(3, "Mathitis"),
                new Ocupation(4, "Taverniaris"),
                new Ocupation(5, "Fournaris"),
                new Ocupation(6, "Mathitis"),
                new Ocupation(7, "Taverniaris"),
                new Ocupation(8, "Mathitis")
            };


            Console.WriteLine("\n\nList without filter");
            Console.WriteLine("Found {0} students", students.Count());
            Console.WriteLine("Found {0} students between 6-21", students.Count(s=> s.StudentAge>=16 && s.StudentAge<=21));
            Console.WriteLine(new String('-',20));
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            // filter 1
            Student[] filter1 = (from student in students where student.StudentName.Contains('o') select student).ToArray();
            Console.WriteLine("\n\nList Filter Names with (o)");
            Console.WriteLine("Found {0} students", filter1.Count());
            Console.WriteLine(new String('-', 20));
            foreach (Student student in filter1)
            {
                Console.WriteLine(student);
            }

            // filter 2
            Student[] filter2 = (from student in students where (student.StudentAge>=16 && student.StudentAge<=21) 
                                 orderby student.StudentAge select student).ToArray();
            Console.WriteLine("\n\nList Filter Ages 16-21 order by Age");
            Console.WriteLine(new String('-', 20));
            foreach (Student student in filter2)
            {
                Console.WriteLine(student);
            }


            // group by
            var group1 = (from student in students group student by student.StudentAge);

            Console.WriteLine("\n\nGroup by Age");
            Console.WriteLine(new String('-', 20));
            foreach (var g in group1)
            {

                Console.WriteLine("Group in Age of {0}" , g.Key);
                Console.WriteLine(new String('-', 5));
                foreach (Student student in g)
                {
                    Console.WriteLine(student);
                }// student loop
                Console.WriteLine(Environment.NewLine);
            }// group loop


            // join Students with Ocupation
            Console.WriteLine("\n\n Join Students with Ocupation");
            Console.WriteLine(new String('-', 20));

            var join1 = from st in students
                        join oc in ocupation on st.StudentID equals oc.StudentID
                        select new Join1Results
                        {
                            StudentID = st.StudentID,
                            StudentName = st.StudentName,
                            StudentAge = st.StudentAge,
                            StudentOcupation = oc.OcuDescr
                        }; 
            foreach (Join1Results jo in join1)
            {
                Console.WriteLine(jo.ToString());
            }

        }//function



    }//class 
}//namespace
