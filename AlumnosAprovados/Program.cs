using System;
using System.IO;
using System.Diagnostics;

namespace AlumnosAprovados
{
    class Program
    {
        static StreamReader Leer;
        static StreamWriter Escritura;

        static string aprovados = "aprovados.txt";
        static string suficiencia = "suficiencia.txt";
        static string desaprovados = "desaprovados.txt";

        struct Alumno
        {
            public string Carnet;
            public string Nombre;
            public double NotaGlobal;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Agregar 10 alumnos a archivos.");
            Console.WriteLine("2 - Abrir archivo aprovados en Notepad.");
            Console.WriteLine("3 - Imprimir aprobados, reprobados o suficiencia.");
            Console.WriteLine("4 - Salir");
            int opcion = int.Parse(Console.ReadLine());

            while (opcion > 0 &&opcion <4)
            {
                switch (opcion)
                {
                    case 1:
                        AgregarAlumnos();
                        break;

                    case 2:
                        AbrirAprovadosNotePad();
                        break;

                    case 4:
                        ElegirOpcion();
                        break;

                    default:
                        break;
                }
            }
        }

        static void AgregarAlumnos()
        {
            Console.Clear();

            for (int i = 0; i < 10; i++)
            {
                Alumno alumno = new Alumno();

                Console.WriteLine("Ingrese el nombre: ");
                alumno.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el carnet: ");
                alumno.Carnet= Console.ReadLine();

                Console.WriteLine("Ingrese el nombre: ");
                alumno.NotaGlobal = double.Parse(Console.ReadLine());

                if(alumno.NotaGlobal >= 5.95 && alumno.NotaGlobal <= 10)
                {
                    Escritura = new StreamWriter(aprovados, true);

                    if (i == 1)
                    {
                        Escritura.WriteLine("ALUMNOS APROVADOS");
                        Escritura.WriteLine("  ");
                    }

                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.WriteLine(alumno.Nombre);
                    Escritura.WriteLine(alumno.Carnet);
                    Escritura.WriteLine(alumno.NotaGlobal);
                    Escritura.WriteLine("-----------------------------------------");
                } else if (alumno.NotaGlobal >5 && alumno.NotaGlobal < 5.95) {
                    if (i == 1)
                    {
                        Escritura.WriteLine("ALUMNOS APTOS PARA PRUEBA DE SUFICIENCIA");
                        Escritura.WriteLine("  ");
                    }

                    Escritura = new StreamWriter(suficiencia, true);

                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.WriteLine(alumno.Nombre);
                    Escritura.WriteLine(alumno.Carnet);
                    Escritura.WriteLine(alumno.NotaGlobal);
                    Escritura.WriteLine("-----------------------------------------");
                } else
                {
                    if (i == 1)
                    {
                        Escritura.WriteLine("ALUMNOS DESAPROVADOS");
                        Escritura.WriteLine("  ");
                    }

                    Escritura = new StreamWriter(desaprovados, true);

                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.WriteLine(alumno.Nombre);
                    Escritura.WriteLine(alumno.Carnet);
                    Escritura.WriteLine(alumno.NotaGlobal);
                    Escritura.WriteLine("-----------------------------------------");
                }
            }
        }

        static void AbrirAprovadosNotePad()
        {
            Process.Start(aprovados);
        }

        static void ElegirOpcion()
        {

        }
    }
}
