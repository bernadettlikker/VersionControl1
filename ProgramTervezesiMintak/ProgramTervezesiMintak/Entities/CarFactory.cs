using ProgramTervezesiMintak.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTervezesiMintak.Entities
{
    class CarFactory: iToyFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
