using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Romanovskiy.Classes
{
    public class Material
    {
        string name;
        double density;

        public Material()
        {

        }

        public Material(string n, double dens)
        {
            this.name = n;
            this.density = dens;
        }

        //мктоды
        public string GetName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double GetDensity
        {
            get
            {
                return density;
            }
            set
            {
                density = value;
            }
        }

        public override string ToString()
        {
            return (name + " : " + density + ";");
        }




    }
}
