using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{


    public class Discipline
    {
        string _name;
        int _year;
        string _profName;
        int[] _gradeExam;
        int[] _gradeLab;
        int _attendance;
        int _type; // distributed ( 0 ) or final exam ( 1 )
        double _k;  // ratio to calculate the average
        public UInt16 _courseHours;
        public UInt16 _labHours;
        public UInt16 _projectHours;
        public UInt16 _credits;
        public string _hall;

        public Discipline(string name, int year, string professorName, int type, UInt16 courseHours, UInt16 labHours, UInt16 projectHours, UInt16 credits, string hall)
        {
            this._name = name;
            this._year = year;
            this._profName = professorName;
            this._type = type;
            this._courseHours = courseHours;
            this._labHours = labHours;
            this._projectHours = projectHours;
            this._credits = credits;
            this._hall = hall;
        }

        public void setRatio(double ratio)
        {
            this._k = ratio;
        }

        public double getRatio()
        {
            return _k;
        }

        public int getDisciplineType()
        {
            return _type;
        }

        public void setGradeExam(int first, int second)
        {
            this._gradeExam[0] = first;
            this._gradeExam[1] = second;
        }

        public void setGradeLab(int grade)
        {
            int i = 0;
            while (_gradeLab[i] != 0)
            { i++; }
            this._gradeLab[i] = grade;
        }

        public void setAttend_yearce(int a)
        {
            this._attendance = a;
        }

        public string getHall()
        {
            return _hall;
        }

        public UInt16 getCourseHours()
        {
            return _courseHours;
        }

        public UInt16 getLabHours()
        {
            return _labHours;
        }

        public UInt16 getProjectHours()
        {
            return _projectHours;
        }

        public UInt16 getCredits()
        {
            return _credits;
        }

        public double getExamGrade()
        {
            if (_gradeExam[1] != 0)
            {
                return (_gradeExam[0] + _gradeExam[1]) / 2;
            }
            else
            {
                return _gradeExam[0];
            }
        }

        public double getDisciplineGrade()
        {
            double avgLab = 0;
            double sum = 0;
            for (int i = 0; i < _gradeLab.Length; i++)
            {
                sum += _gradeLab[i];
            }
            avgLab = sum / _gradeLab.Length;
            return (getExamGrade() * (1 - getRatio()) + getRatio() * avgLab);
        }
    }

    class College
    {
        public string _lastName;
        public string[] _departments { get; set; }

        List<Professor> _professorList;

        public College(string lastName, string[] departments, List<Professor> professorList)
        {
            this._lastName = lastName;
            this._departments = departments;
            this._professorList = professorList;
        }

        public string getName()
        {
            return _lastName;
        }

        public void CreateDisciplineList()
        { }

        public void AssignDisciplines(studentList)
        { }
    }

    public class Person
    {
        public string _lastName;
        public string _firstName;
        public string _address;
        public string _cnp;
        public string _gender;
        public string _dateOfBirth;

        public Person(string lastName, string firstName, string address, string cnp)
        {
            this._lastName = lastName;
            this._firstName = firstName;
            this._address = address;
            this._cnp = cnp;
            this._gender = GetGender(this._cnp[0]);
            this._dateOfBirth = GetDateOfBirth(cnp);
        }

        public string getLastName()
        {
            return _lastName;
        }

        public string getFirstName()
        {
            return _firstName;
        }

        public string getAddress()
        {
            return _address;
        }

        public string getCNP()
        {
            return _cnp;
        }

        public string getGender()
        {
            return _gender;
        }

        public string getDateOfBirth()
        {
            return _dateOfBirth;
        }

        private string GetGender(char s)
        {
            int val = Convert.ToInt16(s);
            string _gender = string.Empty;
            if (s % 2 == 0)
            {
                _gender = "F";
            }
            else
            {
                _gender = "M";
            }
            return _gender;
        }

        private string GetDateOfBirth(string _cnp)
        {
            string dat_yearast = string.Concat(_cnp[5] + "" + _cnp[6] + "." + _cnp[3] + _cnp[4] + ".");
            if (_cnp[0] == '1' || _cnp[0] == '2')
            {
                dat_yearast = dat_yearast + "19" + _cnp[1] + _cnp[2];
            }
            if (_cnp[0] == '3' || _cnp[0] == '4')
            {
                dat_yearast = dat_yearast + "18" + _cnp[1] + _cnp[2];
            }
            if (_cnp[0] == '5' || _cnp[0] == '6')
            {
                dat_yearast = dat_yearast + "20" + _cnp[1] + _cnp[2];
            }
            return dat_yearast;
        }
    }

    public class Student : Person
    {
        UInt16 _mark;
        UInt16 _year { get; set; }
        string _college;
        public Student(string lastName, string firstName, string address, string cnp, UInt16 mark, string college, UInt16 year)
            : base(lastName, firstName, address, cnp)
        {
            this._mark = mark;
            this._year = year;
            this._college = college;
        }

        public UInt16 getMark()
        {
            return _mark;
        }

        public string getCollege()
        {
            return _college;
        }

    }

    public class Professor : Person
    {
        string _department;
        UInt16 _wage { get; set; }
        Discipline[] _disciplines { get; set; }
        public Professor(string lastName, string firstName, string address, string cnp, string department, UInt16 wage, params Discipline[] disciplines)
            : base(lastName, firstName, address, cnp)
        {
            this._department = department;
            this._wage = wage;
            this._disciplines = disciplines;
        }

        public string getDepartment()
        {
            return _department;
        }

    }
}
