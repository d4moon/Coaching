using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Src;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class WorldShould
    {
        [Test]
        public void be_equal_to_empty_world_given_it_is_empty()
        {
            var emptyWorld = new World();
            
            var world = new World();
            
            Assert.That(world, Is.EqualTo(emptyWorld));
        }

        [Test]
        public void not_be_equal_to_empty_world_given_it_is_different()
        {
            var emptyWorld = new World();

            var world = new World(new[,] {{1,1}});

            Assert.That(world, Is.Not.EqualTo(emptyWorld));
        }

        [Test]
        public void be_equal_to_other_world_given_same_configuration()
        {
            var otherWorld = new World(new[,] { { 1, 1 } });

            var world = new World(new[,] { { 1, 1 } });

            Assert.That(world, Is.EqualTo(otherWorld));
        }
    }
}
