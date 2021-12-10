using ProgramTervezesiMintak.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTervezesiMintak.Entities
{
    public class PresentFactory : iToyFactory
    {
        public ConsoleColor PresentColor { get; set; }
        public Toy CreateNew()
        {
            return new Present(PresentColor);
        }
    }
}
