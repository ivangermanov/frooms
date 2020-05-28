using System;
using System.Collections.Generic;
using System.Text;

namespace Froom.Data.Dtos
{
    public class ChartDataDto
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ChartDataSeries> Series { get; set;}
    }

    public class ChartDataSeries
    {
        public string Name { get; set; }

        public IEnumerable<int> Data { get; set; }
    }
}
