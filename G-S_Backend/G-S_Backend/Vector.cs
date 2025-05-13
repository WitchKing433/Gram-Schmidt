using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_S_Backend
{
    public class Vector
    {
        double[] components;

        public Vector(double[] components)
        {
            this.components = new double[components.Length];
            Array.Copy(components, this.components, components.Length);
        }
        public static double ScalarProduct(Vector a, Vector b)
        {
            if (a.Dimension == b.Dimension) 
            {
                double result = 0;
                for (int i = 0; i < a.Dimension; i++)
                {
                    result += a.components[i] * b.components[i];
                }
                return result;
            }
            throw new Exception("Vectors's dimensions must be equal");
        }
        public double Norm()
        {
            return Math.Sqrt(ScalarProduct(this, this));
        }
        public Vector MultiplyScalar(double a)
        {
            double[] newVector = new double[this.Dimension];
            for (int i = 0;i < this.Dimension; i++)
            {
                newVector[i] = this.components[i] * a;
            }
            return new Vector(newVector);
        }
        public Vector DivideScalar(double a)
        {
            double[] newVector = new double[this.Dimension];
            for (int i = 0; i < this.Dimension; i++)
            {
                newVector[i] = this.components[i] / a;
            }
            return new Vector(newVector);
        }

        public int this[int index]
        {
            get
            {
                try
                {
                    return this[index - 1];
                }
                catch
                {
                    throw new Exception($"Unaccessible component, this vector only have {components.Length} components");
                }                
            }
        }

        public int Dimension => components.Length;
    }
}
