using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.DataDAO
{
    public class CensusDataDAO
    {
        //DataAccessObject
        public string state;
        public long population;
        public long area;
        public long density;
        
        public CensusDataDAO(string state,string population,string area,string density)
        {
            this.state = state;
            //converted to 32 bit unsigned integer
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}
