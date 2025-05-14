using System.Numerics;
using G_S_Backend;

namespace Test
{
    internal class Program
    {
        static void Main()
        {
            List<G_S_Backend.Vector> list = new List<G_S_Backend.Vector>();
            G_S_Backend.Vector v = new G_S_Backend.Vector(new double[] {3,57});
            G_S_Backend.Vector u = new G_S_Backend.Vector(new double[] { 87097,2});
            list.Add(v);
            list.Add(u);
            VectorSystem liSys = new VectorSystem(list);
            liSys = liSys.Orthonormalize();
            Console.WriteLine(liSys);
        }
    }
}
