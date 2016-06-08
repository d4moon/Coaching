namespace GameOfLife.Src
{
    public class GameOfLife
    {
        private readonly World _world;

        public GameOfLife(World world)
        {
            _world = world;
        }

        public World Tick()
        {
            return _world;
        }
    }

    public class World
    {
        private readonly int[,] _seed;

        protected bool Equals(World other)
        {
            if (_seed.Length != other._seed.Length)
            {
                return false;
            }

           for (int i = 0; i < _seed.GetLength(0); i++)
            {
                for (int j = 0; j < _seed.GetLength(1); j++)
                {
                    if (_seed[i, j] != other._seed[i, j])
                    {
                        return false;
                    }
                }
                
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((World) obj);
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }

        public World(int[,] seed)
        {
            _seed = seed;
        }

        public World()
        {
            _seed = new int[,]{};
        }

    }

    public class Seed
    {
        public Seed(int[,] seed)
        {

        }
    }
}
