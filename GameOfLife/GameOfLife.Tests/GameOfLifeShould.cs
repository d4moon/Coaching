using GameOfLife.Src;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    /*
       The universe of the Game of Life is an finite 50x50 two-dimensional orthogonal grid of square cells, 
       each of which is in one of two possible states, alive or dead. 
       Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, 
       or diagonally adjacent. At each step in time, the following transitions occur:
       - Any live cell with fewer than two live neighbours dies, as if caused by under-population.
       - Any live cell with two or three live neighbours lives on to the next generation.
       - Any live cell with more than three live neighbours dies, as if by over-population.
       - Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

       The initial pattern constitutes the seed of the system. 
       The first generation is created by applying the above rules simultaneously to every cell in the seed—births and deaths occur simultaneously, 
       and the discrete moment at which this happens is sometimes called a tick (in other words, each generation is a pure function of the preceding one). 
       The rules continue to be applied repeatedly to create further generations.
     */

    [TestFixture]
    public class GameOfLifeShould
    {
        [Test]
        public void return_empty_world_when_ticking_given_empty_seed()
        {
            var emptyWorld = new World();
            var gameOfLife = new Src.GameOfLife(emptyWorld);

            var nextWorld = gameOfLife.Tick();
            
            Assert.That(nextWorld, Is.EqualTo(emptyWorld));
        }

        [Test]
        public void return_empty_world_when_ticking_given_under_populated_world()
        {
            var emptyWorld = new World();
            var underPopulatedWorld = new World(new[,] {{ 0, 0 }});
            var gameOfLife = new Src.GameOfLife(underPopulatedWorld);

            var nextWorld = gameOfLife.Tick();
            
            Assert.That(nextWorld, Is.EqualTo(emptyWorld));
        }

       
    }


}
