﻿using System.Collections.Generic;
using BD_oneLove.Models;

namespace BD_oneLove.Tools.DataStorage
{
    internal interface IDataStorage
    {
        //--------------Plans-----------------

        List<Plan> GetPlans();
        bool AddPlan(Plan p);
        bool UpdatePlan(Plan p, Plan oldP);
        bool DeletePlan(Plan p);

        //--------------Users-----------------

        bool UserExists(string login, string password);
        bool UserExistsUseless(string login);
        User GetUser(string login, string password);
        List<User> GetUsers();
        bool AddUser(User t);
        bool DeleteUser(User t);
        bool UpdateUser(User t, User oldT);

        //--------------Students---------------
        Student SaveStudent(Student s);
        Student UpdateStudent(Student s);
        bool AssignStudentToClass(Student s, Class c);
        bool ExpelStudent(Student s, Class c);

        //--------------Parents---------------
        Parent GetFather(Student s);
        Parent GetMother(Student s);
        List<Parent> GetAllParents();
        bool AssignParentToStudent(Student st, Parent p, bool father);

        //--------------Classes---------------
        Class GetClass(string classId);
        List<Student> GetStudents(Class c);
        List<Parent> GetParentsInClass(Class c);

        //--------------Teachers--------------
        List<string> GetYears();
        List<Teacher> GetTeachers(string year);
        List<Teacher> GetTeachers();
        Teacher UpdateTeacher(Teacher t, Teacher oldT);
        Teacher AddTeacher(Teacher t);
        bool DeleteTeacher(Teacher t);
        bool TeacherExists(string tabNum);


        //-------------Marks-------------------
        bool AddSubject(string subject);
        List<string> GetSubjects(Class c, string type);
        List<Mark> GetMarks(Class c, string subject, string type);
        List<Mark> SaveMarks(List<Mark> l);
        bool RemoveMarks(List<Mark> l);



    }
}