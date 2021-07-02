using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Command[] commands = { new Command("MOVE", 5000), new Command("MODE_CHANGE", "LOW_POWER") };
            Command[] commandsDontMove = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 5000) };
            Message newMessage = new Message("Test message with one command", commandsDontMove);
            Rover newRover = new Rover(98382);    // Passes 98382 as the rover's position.


            Console.WriteLine(newRover.ToString());

            newRover.ReceiveMessage(newMessage);
            Console.WriteLine(newRover.ToString());


        }
    }
}
