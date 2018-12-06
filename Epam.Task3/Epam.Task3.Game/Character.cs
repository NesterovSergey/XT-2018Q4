using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Game
{
    public abstract class Character
    {
        public int Health { get; set; }
        public int Speed { get; set; }
        public int CurrentCoordinates { get; set; }
        public bool Alive { get; set; }

        public abstract void Move();
    }
}
