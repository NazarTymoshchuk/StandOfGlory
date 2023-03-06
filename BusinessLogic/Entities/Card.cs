using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public ICollection<Hero>? Heroes { get; set; }
    }
}
