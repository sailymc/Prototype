// See https://aka.ms/new-console-template for more information
using System;

namespace Prototype
{
    public class Persona
    {
        public IdInfo Id;
        public string Nombre;
        public string Apellido;
        public int Edad;
        public DateTime FechaDeNacimiento;

        public Persona ShallowCopy()
        {
            return (Persona)this.MemberwiseClone();
        }

        public Persona DeepCopy()
        {
            Persona clon = (Persona)this.MemberwiseClone();
            clon.Id = new IdInfo(Id.IdNum);
            clon.Nombre = String.Copy(Nombre);
            clon.Apellido = String.Copy(Apellido);
            return clon;
        }
    }

    public class IdInfo
    {
        public int IdNum;

        public IdInfo(int idNum)
        {
            this.IdNum = idNum;
        }
    }

    class programa
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona();
            p1.Id = new IdInfo(0303);
            p1.Nombre = "Stephen";
            p1.Apellido = "King";
            p1.Edad = 74;
            p1.FechaDeNacimiento = Convert.ToDateTime("21-09-1947");


            Persona p2 = p1.ShallowCopy();
            Persona p3 = p1.DeepCopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Datos originales de p1, p2, p3:");
            Console.WriteLine("   p1 valores de instancia: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 valores de instancia:");
            DisplayValues(p2);
            Console.WriteLine("   p3 valores de instancia:");
            DisplayValues(p3);

            // Cambiando valores
            p1.Id.IdNum = 2021;
            p1.Nombre = "Jenny";
            p1.Apellido = "Aponte";
            p1.Edad = 22;
            p1.FechaDeNacimiento = Convert.ToDateTime("20-10-2022");
            Console.WriteLine("\nValores de p1, p2 y p3 después de los cambios realizados a p1:");
            Console.WriteLine("   p1 valores de instancia: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 valores de instancia (Los datos de referenica han cambiado):");
            DisplayValues(p2);
            Console.WriteLine("   p3 valores de instancia (Los datos siguen igual):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Persona p)
        {
            Console.WriteLine("      Nombre: {0:s},  Apellido: {0:s}, Edad: {1:d}, FechaDeNacimiento: {2:dd/MM/yy}",
                p.Nombre, p.Apellido, p.Edad, p.FechaDeNacimiento);
            Console.WriteLine("      ID#: {0:d}", p.Id.IdNum);
        }
    }
}

