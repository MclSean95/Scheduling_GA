using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McLaughlin_GA
{
    class Day
    {
        public float? availabilityStart { get; set; }
        public float? availabilityEnd { get; set; }

        public Day(float? availabilityStart, float? availabilityEnd) {
            this.availabilityStart = availabilityStart;
            this.availabilityEnd = availabilityEnd;
        }

    }

    class Monday : Day
    {
        public Monday(float? availbiityStart, float? availabilityEnd) : base(availbiityStart, availabilityEnd) { }
    }

    class Tuesday : Day
    {
        public Tuesday(float? availbiityStart, float? availabilityEnd) : base(availbiityStart, availabilityEnd) { }
    }
    class Wednesday : Day
    {
        public Wednesday(float? availbiityStart, float? availabilityEnd) : base(availbiityStart, availabilityEnd) { }
    }
    class Thursday : Day
    {
        public Thursday(float? availbiityStart, float? availabilityEnd) : base(availbiityStart, availabilityEnd) { }
    }
    class Friday : Day
    {
        public Friday(float? availbiityStart, float? availabilityEnd) : base(availbiityStart, availabilityEnd) { }
    }
}
