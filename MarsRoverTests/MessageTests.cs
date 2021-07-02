using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("MOVE", 0), new Command("MOVE", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Message name required.", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newMessage = new Message("Hi", commands);
            Assert.AreEqual(newMessage.Name, "Hi");
        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message newMessage = new Message("Hi", commands);
            Assert.AreEqual(newMessage.Commands, commands);
        }

    }
}
