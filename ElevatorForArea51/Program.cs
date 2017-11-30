using ElevatorForArea51.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ElevatorForArea51
{
    class Program
    {

        // Config
        private const int AGENTS_NUMBER = 5;
        public const int THREAD_SLEEP = 2000;

        // Random + Agents list
        public static Random random = new Random();
        public static List<Agent> agents = new List<Agent>();

        // Main
        static void Main(string[] args)
        {

            // Create agents
            for(int i = 0; i < AGENTS_NUMBER; i++)
            {
                agents.Add(new Agent());
                Thread.Sleep(150);
            }

            // Start the magic process
            var elevator = new Thread(ElevatorWorker);
            elevator.Start();
            elevator.Join();

            // Done, display exit info
            Console.WriteLine("===============================");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();

        }

        // Elevator Worker
        public static void ElevatorWorker()
        {
            foreach(Agent agent in agents)
            {
                var agentThread = new Thread(agent.UseElevator);
                agentThread.Start();
                agentThread.Join();
            }
        }

    }
}
