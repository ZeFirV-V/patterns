using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClubExample.Products.Interfaces
{
    internal interface IMembership
    {
        string Name { get; }
        string Description { get; set; }
        decimal GetPrice();
    }
}
