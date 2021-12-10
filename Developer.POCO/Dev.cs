using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.POCO
{

    public class Dev 
    {
        //properties
        // Names, ID Numbers, did they have access to the online learning tool: Pluralsight True or False

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DevID { get; set; }

        public bool isAccessingPluralsight { get; set; }

        public Dev() { }

        public Dev(string firstName, string lastName, int devId, bool hasPluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            DevID = devId;
            isAccessingPluralsight = hasPluralsight;
        }

        public Dev(string firstName, string lastName)

        {
            FirstName = firstName;
            LastName = lastName;
            }
    }
}
