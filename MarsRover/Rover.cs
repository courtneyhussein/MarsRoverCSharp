using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public void ReceiveMessage(Message message)
        {
            foreach (Command instructions in message.Commands)
            {
                if (instructions.CommandType == "MODE_CHANGE")
                {
                    this.Mode = instructions.NewMode;
                }
                else if (instructions.CommandType == "MOVE")
                {
                    if (this.Mode == "NORMAL")
                    {
                        this.Position = instructions.NewPostion;
                    }
                }
            }
        }



        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
