using System;
using System.Diagnostics;
using System.Linq;
using Models;
namespace EFCoreApplication
{
    class Project
    {
        public static void Main()
        {
            using var db = new EmplooyeesesContext();
            Console.WriteLine($"Database path : {db.Dbpath}");
            Console.WriteLine("Inserting a new employee");

            Emplooyeeses employeess0 = new Emplooyeeses { EID = 2, Name = "Rajan Yadav", DID = 10 };
            Emplooyeeses employeess1 = new Emplooyeeses { EID = 3, Name = "Ram Mandal", DID = 10 };
            Emplooyeeses employeess2 = new Emplooyeeses { EID = 1, Name = "Gyan Thapa", DID = 10 };

            db.Add(employeess0);
            db.Add(employeess1);
            db.Add(employeess2);
            db.SaveChanges();

            Console.WriteLine("Querying for all Emploooyee Ordered by Name alphabetically");

            List<Emplooyeeses> allEmployee = db.Emplooyeeses
            .OrderBy(E => E.Name)
            .ToList();

            foreach (var Emplooyeeses in allEmployee)
            {
                Console.WriteLine($"EID : {Emplooyeeses.EID}");
                Console.WriteLine($"Name : {Emplooyeeses.Name}");
            }

            Emplooyeeses firstEmployee = db.Emplooyeeses
                .OrderBy(b => b.EID)
                .First();

            EmplooyeesesLeave employeeLeave = new EmplooyeesesLeave { LeaveID = 1, EmployeeeId = firstEmployee.EID, NumOfDate = 2 };
            db.Add(employeeLeave);
            db.SaveChanges();

            EmplooyeesesLeave firstLeave = db.EmplooyeesesLeaves.Where(el => el.EmployeeeId == firstEmployee.EID).First();

            Console.WriteLine($"Leave applied by first emaployee for {firstLeave.NumOfDate} day");

            db.Remove(firstLeave);

            Console.WriteLine($"First EID : {firstEmployee.EID} with Name : {firstEmployee.Name}");
            db.Remove(employeess0);
            db.Remove(employeess1);
            db.Remove(employeess2);
            db.SaveChanges();
        }

    }
}
