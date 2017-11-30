using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorForArea51.Models
{
    class Agent
    {

        // Levels
        public enum Levels { Confidential, Secret, TopSecret }; // Levels of access
        public static int levelsNumber = Enum.GetNames(typeof(Levels)).Length; // Number of levels

        // Properties
        public static int AgentsCount = 0;
        public int Id { get; }
        public int Level { get; }
        public int FloorNow { get; set; }

        // Constructor
        public Agent()
        {
            Id = ++AgentsCount;
            Level = Program.random.Next(levelsNumber);
            FloorNow = (int)Elevator.Floors.G;
            Console.WriteLine("Agent " + Id + ", level " + Level);
        }

        // Because walking is not good for you
        public void UseElevator()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("[AGENT " + Id + "] CALL");
            Elevator.Move(this.FloorNow);
            Console.WriteLine("[AGENT " + Id + "] ENTER");
            Elevator.Agent = this;
            Elevator.Use();
            Console.WriteLine("[AGENT " + Id + "] SUCCESS");
            /*
            Program.agents.Add(Program.agents[0]);
            Program.agents.RemoveAt(0);
            */
        }

    }
}
