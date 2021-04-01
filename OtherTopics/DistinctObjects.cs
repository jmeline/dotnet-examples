using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace OtherTopics
{
    public class DistinctObjects
    {
        public class Person : IEquatable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public bool Equals(Person other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Name == other.Name && Age == other.Age;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Person) obj);
            }

            public override int GetHashCode()
            {
                // HasCode.Combine will take each argument and call .GetHashCode on it
                return HashCode.Combine(Name, Age);
            }
        }

        public class Roster
        {
            public string Subject { get; set; }
            public List<Person> Persons { get; set; }
        }


        [Fact]
        public void TestOneLevelDistinctObjects()
        {
            var roster = new Roster
            {
                Persons = new List<Person>
                {
                    new Person {Name = "bob", Age = 32},
                    new Person {Name = "bob", Age = 32},
                    new Person {Name = "bob", Age = 32},
                    new Person {Name = "bob", Age = 32},
                    new Person {Name = "bob", Age = 32},
                    new Person {Name = "bob", Age = 32},
                    new Person {Name = "jim", Age = 30},
                    new Person {Name = "jim", Age = 30},
                    new Person {Name = "jim", Age = 30},
                    new Person {Name = "doug", Age = 42},
                    new Person {Name = "doug", Age = 42},
                    new Person {Name = "doug", Age = 42},
                    new Person {Name = "bob", Age = 32}
                }
            };

            var results = roster.Persons.Distinct();
            results.Count().ShouldBe(3);
        }

        public class University : IEquatable<University>
        {
            public string School { get; set; }
            public List<Course> Courses { get; set; }

            public bool Equals(University other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return School == other.School && Equals(Courses, other.Courses);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((University) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(School, Courses);
            }
        }

        public class Course : IEquatable<Course>
        {
            public string Subject { get; set; }
            public List<Person> Students { get; set; }

            public bool Equals(Course other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Subject == other.Subject && Students.SequenceEqual(other.Students);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Course) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Subject, Students);
            }
        }
        
        [Fact]
        public void TestTwoLevelDistinctObjects()
        {
            var university = new University
            {
                School = "USU",
                Courses = new List<Course>
                {
                    new Course
                    {
                        Subject = "Chemistry",
                        Students = new List<Person>
                        {
                            new Person {Name = "Jim", Age = 28},
                            new Person {Name = "Jack", Age = 25},
                            new Person {Name = "Jack", Age = 25},
                            new Person {Name = "Joe", Age = 30}
                        }
                    },
                    new Course
                    {
                        Subject = "Chemistry",
                        Students = new List<Person>
                        {
                            new Person {Name = "Jim", Age = 28},
                            new Person {Name = "Jack", Age = 25},
                            new Person {Name = "Jack", Age = 25},
                            new Person {Name = "Kaitlin", Age = 29}
                        }
                    },
                    new Course
                    {
                        Subject = "CS",
                        Students = new List<Person>
                        {
                            new Person {Name = "Jacob", Age = 33},
                            new Person {Name = "Jim", Age = 28},
                            new Person {Name = "Jack", Age = 25},
                            new Person {Name = "Jack", Age = 25}
                        }
                    }
                }
            };
            // I wonder what is going to happen?
            // var results = university.Courses.Distinct();
            var results = university.Courses
                .SelectMany(x => x.Students)
                .Distinct()
                .ToList();
            // .GroupBy(arg =>  arg.Name)
            // .Select(g => g.)


        }
    }
}