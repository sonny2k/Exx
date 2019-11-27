using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exx.StudentManagement
{
    public class LogicLayer
    {
        public Student[] GetStudents()
        {
            var db = new MyDBEntities();
            return db.Students.ToArray();
        }

        public Student GetStudent(int id)
        {
            var db = new MyDBEntities();
            return db.Students.Find(id);
        }

        public void CreateStudent(string code, string name, DateTime birthday, int class_id)
        {
            var student = new Student();
            student.Code = code;
            student.Name = name;
            student.Birthday = birthday;
            student.Class_id = class_id;

            var db = new MyDBEntities();
            db.Students.Add(student);
            db.SaveChanges();
        }
        
        public void UpdateStudent(int id, string name, DateTime birthday, int class_id)
        {
            var db = new MyDBEntities();
            var student = db.Students.Find(id);

            student.Name = name;
            student.Birthday = birthday;
            student.Class_id = class_id;

            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var db = new MyDBEntities();
            var student = db.Students.Find(id);

            db.Students.Remove(student);
            db.SaveChanges();
        }

        public Class[] GetClasses()
        {
            var db = new MyDBEntities();
            return db.Classes.ToArray();
        }
    }
}
