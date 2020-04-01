using Froom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Froom.UnitTest.Helpers
{
    /// <summary>
    /// Keeps sample data to be used in the unit tests
    /// </summary>
    public static class SeededData
    {
        public static User NormalUser { get; set; }

        public static Building Building1 { get; set; }

        /// <summary>
        /// Room in Building1
        /// </summary>
        public static Room Room1 { get; set; }
    }
}