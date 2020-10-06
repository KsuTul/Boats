using Boatstorage.Data.Mapping;

namespace Boatstorage.Data
{
    public class Catamaran : FloatingCrafts, IBoat
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
}