using System;
using Domain.Entities;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        
        private AdjacencyMatrix _matrix = new AdjacencyMatrix(new []
        {
            new []{0, 2, 4, 12, Int32.MaxValue},
            new []{2, 0, 8, Int32.MaxValue, 25},
            new []{4, 0, 8, 10, Int32.MaxValue},
            new []{12, Int32.MaxValue, 10, 0, 7},
            new []{Int32.MaxValue, 25, Int32.MaxValue, 7, 0},
        });
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            new ShortcutCalculator().Shortcuts(_matrix, 1);
            Assert.Pass();
        }
    }
}