using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public class Achievement : BaseEntity
    {
        public int RaceWins { get; set; }
        public int PolePositions { get; set; }
        public int FastestLap { get; set; }

        public int WorldChampionShip { get; set; }

        public Guid DriverId { get; set; }


        public virtual Driver? Driver { get; set; }
    }
}
