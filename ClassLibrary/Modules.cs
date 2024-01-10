using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Modules
    {
        //getters and setters

        public int MODULE_ID
        {
            get; set;
        }

        public string ModuleCode
        {
            get; set;
        }

        public string ModuleName
        {
            get; set;
        }

        public int NumberOfCreadits
        {
            get; set;
        }

        public int ClassHoursPerWeek
        {
            get; set;
        }

        public int NumberOfWeeks
        {
            get; set;
        }

        public string StartDate
        {
            get; set;
        }

        public int HoursSpend
        {
            get; set;
        }

        public string SelfStudyhoursPerWeek
        {
            get; set;
        }

        public string EndDate
        {
            get; set;
        }

        public int HoursRemaining
        {
            get; set;
        }



        //constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Modules() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        //overloaded constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Modules(string moduleCode, string moduleName, int numberOfCredits, int classHoursPerWeek, int numberOfWeeks, string startDate, string endDate)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

            ModuleCode = moduleCode;
            ModuleName = moduleName;
            NumberOfCreadits = numberOfCredits;
            ClassHoursPerWeek = classHoursPerWeek;
            NumberOfWeeks = numberOfWeeks;
            StartDate = startDate;
            EndDate = endDate;


        }



        public static int selfHours(int selfStudy_hoursPerWeek, int numberOfCredits, int numberOfWeeks, int classHoursPerWeek)
        {
            selfStudy_hoursPerWeek = numberOfCredits * 10 / numberOfWeeks - classHoursPerWeek;

            return selfStudy_hoursPerWeek;
        }
    }
}
