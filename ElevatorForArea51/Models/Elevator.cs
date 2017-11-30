using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ElevatorForArea51.Models
{
    class Elevator
    {

        // Floors
        public enum Floors { G, S, T1, T2 }; // Floors
        public static int floorsNumber = Enum.GetNames(typeof(Floors)).Length; // Number of floors

        // Properties
        public static Agent Agent { get; set; } = null;
        public static int FloorNow { get; set; } = (int)Floors.G;

        // Move elevator
        public static void Move(int FloorMove)
        {
            Thread.Sleep(Program.THREAD_SLEEP);
            Console.WriteLine("[ELEVATOR] From: " + FloorNow);
            int TravelTime = 1000 * Math.Abs(FloorNow - FloorMove);
            Thread.Sleep(TravelTime);
            FloorNow = FloorMove;
            Console.WriteLine("[ELEVATOR] To: " + FloorNow + " (" + TravelTime + " ms)");
            Thread.Sleep(Program.THREAD_SLEEP);
        }

        // Use elevator
        public static void Use()
        {
            bool HasAccessLoop = true;
            do
            {
                int FloorEnd = Program.random.Next(floorsNumber);
                Thread.Sleep(Program.THREAD_SLEEP);
                Console.WriteLine("[AGENT " + Agent.Id + ", level " + Agent.Level + "] wants floor " + FloorEnd);
                Thread.Sleep(Program.THREAD_SLEEP);
                if (HasAccess(FloorEnd))
                {
                    Console.WriteLine("access granted");
                    Move(FloorEnd);
                    Agent.FloorNow = FloorEnd;
                    HasAccessLoop = false;
                } else
                    Console.WriteLine("access denied");
            } while (HasAccessLoop);
        }

        // Check if agent has accent to a certain floor
        private static bool HasAccess(int Floor)
        {
            if (Agent.Level == (int)Agent.Levels.Confidential && Floor == 0)
                return true;
            else if (Agent.Level == (int)Agent.Levels.Secret && Floor <= 1)
                return true;
            else if (Agent.Level == (int)Agent.Levels.TopSecret)
                return true;
            return false;
        }

    }
}
