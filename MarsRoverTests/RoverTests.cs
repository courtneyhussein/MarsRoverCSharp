using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {

        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover newRover = new Rover(98382);
            Assert.AreEqual(newRover.Position, 98382, .001);

        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newRover = new Rover(98382);
            Assert.AreEqual(newRover.Mode, "NORMAL");

        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newRover = new Rover(98382);
            Assert.AreEqual(newRover.GeneratorWatts, 110, .001);

        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Command[] commands = { new Command("MOVE", 5000), new Command("MODE_CHANGE", "LOW_POWER") };
            Message newMessage = new Message("Test message with one command", commands);
            Rover newRover = new Rover(98382);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Mode, "LOW_POWER");
        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 5000) };
            Message newMessage = new Message("Test message with one command", commands);
            Rover newRover = new Rover(98382);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Position, 98382, .001);
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] commands = { new Command("MOVE", 5000), new Command("MODE_CHANGE", "LOW_POWER") };
            Message newMessage = new Message("Test message with one command", commands);
            Rover newRover = new Rover(98382);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Position, 5000, .001);
        }
    }
}
