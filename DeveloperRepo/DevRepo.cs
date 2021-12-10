using Developer.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepo
{
    public class DevRepo
    {

        //List of Business Objects
       private readonly List<Dev> _devlist = new List<Dev>(); //this is a field

        private int _count = 0; //setting field

        //Create a developer
        public bool AddDeveloperToList(Dev developer) //class info into holder name for info
        {
            if(developer == null)
            {
                return false;
            }
            _count++;
            developer.DevID = _count;
            _devlist.Add(developer);
            return true;
        }


        //Read directory of developers
        public List<Dev> GetDeveloperList()
        {
            return _devlist;
        }
        
        //Getting developer by ID
        public Dev GetDeveloperById(int id)
        {
            foreach(Dev developer in _devlist)
            {
                if (id == developer.DevID)
                {
                    return developer;
                }
            }
            return null;
        }

        //Update developer info (we want to know if it was returned or not)
        public bool UpdateDeveloper(int id, Dev newDeveloperData)
        {
            Dev oldDeveloperData = GetDeveloperById(id);
            if(oldDeveloperData != null)
            {
                oldDeveloperData.DevID = newDeveloperData.DevID;
                oldDeveloperData.FirstName = newDeveloperData.FirstName;
                oldDeveloperData.LastName = newDeveloperData.LastName;
                oldDeveloperData.isAccessingPluralsight = newDeveloperData.isAccessingPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete remove developer
        public bool RemoveDeveloperFromList(int id)
        {
            Dev developerToBeYeeted = GetDeveloperById(id);
            if (developerToBeYeeted == null)
            {
                return false;
            }
            else
            {
                _devlist.Remove(developerToBeYeeted);
                return true;
            }
        }


        //helper method

                                             
    }
}
