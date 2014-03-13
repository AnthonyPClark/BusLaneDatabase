using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusLaneDatabase;
using BusLaneDatabase.Controllers;
using BusLaneDatabase.Models;
using BusLaneDatabase.Entities;

namespace BusLaneDatabase.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
       
        [TestMethod]
        public void TestBusLaneColour()
        {
            //Arrange
            BusLaneModel buslane = new BusLaneModel();

            //Act
            buslane.colour = "red";

            //Assert
            Assert.AreEqual("red", buslane.colour);

        }

        [TestMethod]
        public void TestBusLaneSingleDayOperatingTimes()
        {
            //Arrange

            BusLaneModel buslane = new BusLaneModel();

            TimeSpan starttime = new TimeSpan(9,0,0);
            OperatingPeriod period = new OperatingPeriod();
            period.starttime = new TimeSpan(9, 0, 0);
            period.duration = 8;
            //Act
            //Scenario is to test setting times for a single day
            buslane.SetOperatingTimesFor("Monday", starttime, 8);

            //Assert
            Assert.AreEqual(8, buslane.GetOperatingPeriodFor("Monday").duration);
            Assert.AreEqual(new TimeSpan(9, 0, 0), buslane.GetOperatingPeriodFor("Monday").starttime); 
        }

        public void TestVehiclesPermitted() { 
        //rule is that at least one vehicle is permitted and there must be at least one type of bus permitted
        // bus, local bus, bus & coach
        // can only have one of those three (but you have to have one)
        }

        public void TestLengthOfBusLane() { 
        //must be more than 1m
        //held as an int to the nearest m
        }

        public void TestIsInPeakHours() { 
          //peak hours are 8-10 and 16-18 Monday to Friday 
        }

        public void TestIsInInterPeak() { 
         //interpeak is 10-16 monday to friday
        }

        public void TestInNeitherPeakNorInterpeak() { 
        }

        public void TestIfBuslaneIsSuspended() { 
           //build method to set suspension some time in the future and then 
           //test using two dates, one non suspended and one suspended.
        }
        /*
         public void TestIfBusLaneWasSuspended(){
           get historical information pertaining to a bus lane suspension 
         }
         */



        
        /* [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }*/
    }
}
