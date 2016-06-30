using System.Collections.Generic;
using System.Data;
using System.Linq;
using FluentAssertions;
using GameOfLife.Src;
using NUnit.Framework;
using GameOfLife = GameOfLife.Src.GameOfLife;

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
        public void have_dead_cell_given_an_empty_world()
        {
            var world = new World();
            var position = new Position(0,0);

            var cellStatus = world.GetCellStatus(position);

            Assert.That(cellStatus, Is.EqualTo(CellStatus.Dead));
        }

        [TestCase(0,0,CellStatus.Alive)]
        [TestCase(1, 1, CellStatus.Dead)]
        public void have_dead_cell_given_a_valid_seed(int x, int y, CellStatus expectedCellStatus)
        {
            var positions = new List<Position>
                                {
                                    new Position(0, 0)
                                };

            var world = new World(positions);
            var position = new Position(x,y);

            var cellStatus = world.GetCellStatus(position);

            Assert.That(cellStatus, Is.EqualTo(expectedCellStatus));
        }


        //[Test]
        //public void kill_a_cell_given_there_is_only_one_cell_before_next_generation()
        //{
        //    var world = new World();

        //    world.RunNextGeneration();

        //    var cellStatus = world.GetCellStatus(1, 1);
        //    cellStatus.Should().Be(CellStatus.Dead);
        //}

        //[Test]
        //public void kill_a_cell_given_it_has_one_live_neighbour()
        //{
        //    var positions = new List<Position>
        //                    {
        //                        new Position(0, 0),
        //                        new Position(0, 1)
        //                    };
        //    var world = new World(positions);

        //    world.RunNextGeneration();

        //    var cellStatus = world.GetCellStatus(1, 1);
        //    cellStatus.Should().Be(CellStatus.Dead);
        //}

        //[Test]
        //public void keep_a_cell_alive_given_it_has_two_live_neighbours()
        //{
        //    var positions = new List<Position>
        //                    {
        //                        new Position(0, 0),
        //                        new Position(0, 1),
        //                        new Position(1, 0)
        //                    };
        //    var world = new World(positions);

        //    world.RunNextGeneration();

        //    var cellStatus = world.GetCellStatus(1, 1);

        //    cellStatus.Should().Be(CellStatus.Alive);
        //}
    }

    public class Position
    {
        protected bool Equals(Position other)
        {
            return _row == other._row && _column == other._column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_row*397) ^ _column;
            }
        }

        private int _row;
        private int _column;
        
        public Position(int row, int column)
        {
            _row = row;
            _column = column;
        }
    }


    public class World
    {
        private readonly List<Position> _positions;

        public World(List<Position> positions)
        {
            _positions = positions;
        }

        public World()
        {
        }

        public CellStatus GetCellStatus(Position position)
        {
            if (_positions != null && _positions.Any(p=>p.Equals(position)))
            {
                return CellStatus.Alive;
            }
            return CellStatus.Dead;
        }
    }

    public enum CellStatus
    {
        Dead,
        Alive
    }
}
