﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace G_S_Backend
{
    public class VectorSystem : IEnumerable<Vector>
    {
        List<Vector> vectors;

        public VectorSystem(List<Vector> vectors)
        {
            this.vectors = new List<Vector>(vectors);  
        }
        public VectorSystem(Vector vector)
        {
            this.vectors = new List<Vector> {vector};
        }
        public void AddVector(Vector vector) => vectors.Add(vector);
        public void RemoveVector(int index)
        {
            try
            {
                vectors.RemoveAt(index - 1);
            }
            catch
            {
                throw new Exception($"Unaccessible vector, this vectors system only have {VectorsCount} vectors");
            }
        }
        public VectorSystem Orthonormalize()
        {
            List<Vector> vectorsSystem = new List<Vector>();
            vectorsSystem.Add(vectors[0].DivideScalar(vectors[0].Norm()));
            for (int i = 1; i < VectorsCount; i++) 
            {
                Vector newVector = vectors[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    newVector = newVector - (Vector.ScalarProduct(vectors[i], vectorsSystem[j]) * vectorsSystem[j]);
                }
                newVector = newVector / newVector.Norm();
                vectorsSystem.Add(newVector);
            }
            return new VectorSystem(vectorsSystem);
        }
        public IEnumerator<Vector> GetEnumerator()
        {
            return (IEnumerator<Vector>)vectors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int VectorsCount => vectors.Count;
        public Vector this[int index] 
        {
            get 
            {
                return vectors[index - 1];
            }
        }
        public override string ToString()
        {
            string vSystem = "{ ";
            for (int i = 0; i < VectorsCount; i++)
            {
                vSystem += vectors[i].ToString();
                if (VectorsCount - 1 != i)
                    vSystem += ", ";
            }
            vSystem += "}";
            return vSystem;
        }

    }
}
