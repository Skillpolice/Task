using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Romanovskiy.Classes
{
    public class UniformSubject
    {
        Material material;
        string name;
        double volume;

        public UniformSubject()
        {

        }

        public UniformSubject(string n, double vol, Material mat)
        {
            this.material = mat;
            this.name = n;
            this.volume = vol;
        }

        //Свойства
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

        public double GetVolume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }

        public Material GetSetMat
        {
            get
            {
                return material;
            }
            set
            {

                material = value;
            }
        }

        //Методы
        public double GetMass()
        {
            return (volume * material.GetDensity);
        }

        public override string ToString()
        {
            return (name + " : " + material + " : " + volume + " : " + GetMass());
        }












    }
}
