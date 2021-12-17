using System;

namespace Proyecto_SSRB
{
    public class Bache
    {
        public int size;
        public DateTime creationDate;
        public string address;
        public string district;
        public string position;
        public int priority;
        public IdInfo IdInfo;

        public Bache ShallowCopy()
        {
            return (Bache)this.MemberwiseClone();
        }

        [Obsolete]
        public Bache DeepCopy()
        {
            Bache clone = (Bache)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.address = String.Copy(address);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            Bache p1 = new Bache();
            p1.size = 3;
            p1.creationDate = Convert.ToDateTime("2018-07-04");
            p1.address = "Av. Luperon";
            p1.district = "Los Restauradores";
            p1.priority = 1;
            p1.position = "Medio de la calle";
            p1.IdInfo = new IdInfo(645);

            // Perform a shallow copy of p1 and assign it to p2.
            Bache p2 = p1.ShallowCopy();
            // Make a deep copy of p1 and assign it to p3.
            Bache p3 = p1.DeepCopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Valores originales de p1, p2, p3 (p representan los baches):");
            Console.WriteLine("   p1 instancia los valores: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instancia los valores:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instancia los valores:");
            DisplayValues(p3);

            // Change the value of p1 properties and display the values of p1,
            // p2 and p3.
            p1.size = 5;
            p1.creationDate = Convert.ToDateTime("2019-07-21");
            p1.address = "Av. Lope de Vega";
            p1.IdInfo.IdNumber = 732;
            Console.WriteLine("\nValores de p1, p2 y p3 luego de hacer cambios en p1:");
            Console.WriteLine("   p1 instancia los valores: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instancia los valores (los valores de referencia han cambiado):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instancia los valores (todo se mantiene igual):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Bache p)
        {
            Console.WriteLine("      Direccion: {0:s}, Tamaño: {1:d}, Fecha de creacion: {2:MM/dd/yy}",
                p.address, p.size, p.creationDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}
