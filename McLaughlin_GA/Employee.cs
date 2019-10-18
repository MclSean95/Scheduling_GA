using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McLaughlin_GA
{
    class Employee
    {
        #region Properties
        List<Day> days = new List<Day>();
        string name;
        int employeeID;
        int hoursWorked = 0;
        #endregion

        #region Consrtuctor
        public Employee(float? [] availability, string name, int employeeID)
        {
            //Set the days of the week to include the proper availability.
            days.Add(new Monday(availability[0], availability[1]));
            days.Add(new Tuesday(availability[2], availability[3]));
            days.Add(new Wednesday(availability[4], availability[5]));
            days.Add(new Thursday(availability[6], availability[7]));
            days.Add(new Friday(availability[8], availability[9]));

            this.name = name;
            this.employeeID = employeeID;
        }
        #endregion

        #region Helper Methods
        public float? GetAvailabilityStart(int ndx)
        {
            return days[ndx].availabilityStart;
        }

        public float? GetAvailabilityEnd(int ndx)
        {
            return days[ndx].availabilityEnd;
        }

        public int HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked += value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
        }
        #endregion
    }
}
