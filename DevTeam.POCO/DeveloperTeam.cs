using Developer.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam.POCO
{
    public class DeveloperTeam
    {

        //properties
        public List<Dev> GetDeveloperList { get; set; }

        public string TeamName { get; set; }
        public int TeamID { get; set; }

        public DeveloperTeam() { }

        public DeveloperTeam(string teamName, int id, List<Dev> devs)
        {
            TeamName = teamName;
            TeamID = id;
            GetDeveloperList = devs;
        }

        //Team member(developers), team name and team ID

        


        //manager ability to add and remove members to/from a team by their unique ID
        //Able to se a list of existing developers to choose from and add to existing teams
        //manager will create a team and then add developers individually from developer directory to that team
      

    }
}
