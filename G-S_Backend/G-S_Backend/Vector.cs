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

        public static Vector operator +(Vector a, Vector b)
        {
            return AddVectors(a,b);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return SubtractVectors(a, b);
        }
        public static Vector operator *(Vector a, double b)
        {
            return a.MultiplyScalar(b);
        }
        public static Vector operator *(double b, Vector a)
        {
            return a.MultiplyScalar(b);
        }
        public static Vector operator /(Vector a, double b)
        {
            return a.DivideScalar(b);
        }
        public static Vector AddVectors(Vector a, Vector b)
        {
            if (a.Dimension == b.Dimension) 
            {
                double[] newVector = new double[a.Dimension];
                for (int i = 0; i < a.Dimension; i++)
                {
                    newVector[i] = a.components[i] + b.components[i];
                }
                return new Vector(newVector);
            }
            throw new Exception("Vectors's dimensions must be equal");
        }
        public static Vector SubtractVectors(Vector a, Vector b)
        {
            if (a.Dimension == b.Dimension)
            {
                double[] newVector = new double[a.Dimension];
                for (int i = 0; i < a.Dimension; i++)
                {
                    newVector[i] = a.components[i] - b.components[i];
                }
                return new Vector(newVector);
            }
            throw new Exception("Vectors's dimensions must be equal");
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

        public double this[int index]
        {
            get
            {
                try
                {
                    return components[index - 1];
                }
                catch
                {
                    throw new Exception($"Unaccessible component, this vector only have {components.Length} components");
                }                
            }
        }
        public override string ToString()
        {
            string vector = "( ";
            for (int i = 0; i < Dimension; i++)
            {
                vector += components[i].ToString();
                if(Dimension - 1 != i)
                    vector += ", ";
            }
            vector += ")";
            return vector;
        }
        public int Dimension => components.Length;
    }
}
