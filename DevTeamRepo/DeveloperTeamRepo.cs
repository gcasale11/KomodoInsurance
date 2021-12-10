using Developer.POCO;
using DevTeam.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepo
{
    public class DeveloperTeamRepo
    {
        public List<DeveloperTeam> _devTeamList = new List<DeveloperTeam>();

        private int _count = 0;

        //Create

        public bool CreateTeam(DeveloperTeam devTeam)
        {
            if (devTeam == null)
            {
                return false;
            }
            else
            {
                _count++;
                devTeam.TeamID = _count;
                _devTeamList.Add(devTeam);
                return true;
            }
        }

        //Read
        public List<DeveloperTeam> ViewDeveloperTeamList()
        {
            return _devTeamList;
        }
        //get team by ID
        public DeveloperTeam GetTeamById(int id)
        {
            foreach (DeveloperTeam team in _devTeamList)
            {
                if (id == team.TeamID)
                {
                    return team;
                }
            }
            return null;
        }

        //Update
        public bool UpdateTeam(int id, DeveloperTeam newTeamData)
        {
            DeveloperTeam oldTeamData = GetTeamById(id);
            if (oldTeamData != null)
            {
                oldTeamData.TeamID = newTeamData.TeamID;
                oldTeamData.TeamName = newTeamData.TeamName;
                oldTeamData.GetDeveloperList = newTeamData.GetDeveloperList;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveTeam(int id)
        {
            DeveloperTeam teamToBeYeeted = GetTeamById(id);
            if (teamToBeYeeted == null)
            {
                return false;
            }
            else
            {
                _devTeamList.Remove(teamToBeYeeted);
                return true;
            }
        }

        public List<Dev> RemoveTeamMember(int id, int memberId)
        {
            var team = GetTeamById(id);
            var newList = team.GetDeveloperList;

            foreach (var teamMember in team.GetDeveloperList)
            {
                if (teamMember.DevID == memberId)
                {
                    newList.Remove(teamMember);
                }
                team.GetDeveloperList = newList;
                return team.GetDeveloperList;
            }
            return null;

        }

        public List<Dev> AddTeamMember(int id, int memberId)
        {
            var team = GetTeamById(id);
            var newList = team.GetDeveloperList;

            foreach (var teamMember in team.GetDeveloperList)
            {
                if (teamMember.DevID == memberId)
                {
                    newList.Add(teamMember);
                }
                team.GetDeveloperList = newList;
                return team.GetDeveloperList;
            }
            return null;

        }

        public string DisplayingListOfDevelopers(int id)
        {
            var team = GetTeamById(id);
            var listOfDevs = team.GetDeveloperList;
            List<string> names = new List<string>();

            foreach(var devs in listOfDevs)
            {
                string name = devs.FirstName;
                names.Add(name);
            }
            string listItem = String.Join(", ", names);
            return listItem;
        }


    }
}
