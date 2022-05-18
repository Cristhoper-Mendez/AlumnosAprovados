using System;
using System.IO;
using System.Diagnostics;

namespace AlumnosAprovados
{
    class Program
    {

        static string directorio = Directory.GetCurrentDirectory();
        static string aprovados = directorio + "\\aprovados.txt";
        static string suficiencia = directorio + "\\suficiencia.txt";
        static string desaprovados = directorio + "\\desaprovados.txt";

        static int opcionMenu;

        struct Alumno
        {
            public string Carnet;
            public string Nombre;
            public double NotaGlobal;
        }
        static void Main(string[] args)
        {
            MostrarMenu();

            while (opcionMenu > 0 && opcionMenu < 4)
            {
                switch (opcionMenu)
                {
                    case 1:
                        AgregarAlumnos();
                        break;

                    case 2:
                        AbrirAprovadosNotePad();
                        break;

                    case 3:
                        ElegirOpcion();
                        opcionMenu = 4;
                        break;

                    default:
                        break;
                }
            }
        }

        static void AgregarAlumnos()
        {
            Console.Clear();

            for (int i = 0; i < 1; i++)
            {
                Console.Clear();

                Alumno alumno = new Alumno();

                Console.WriteLine("Ingrese el nombre: ");
                alumno.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el carnet: ");
                alumno.Carnet = Console.ReadLine();

                Console.WriteLine("Ingrese el la nota global: ");
                alumno.NotaGlobal = double.Parse(Console.ReadLine());

                if (alumno.NotaGlobal >= 5.95 && alumno.NotaGlobal <= 10)
                {
                    StreamWriter Escritura = new StreamWriter("aprovados.txt", true);

                    if (i == 1)
                    {
                        Escritura.WriteLine("ALUMNOS APROVADOS");
                        Escritura.WriteLine("  ");
                    }

                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.WriteLine("Nombre: " + alumno.Nombre);
                    Escritura.WriteLine("Carnet: " + alumno.Carnet);
                    Escritura.WriteLine("Nota global: " + alumno.NotaGlobal);
                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.Close();
                }
                else if (alumno.NotaGlobal > 5 && alumno.NotaGlobal < 5.95)
                {
                    StreamWriter Escritura = new StreamWriter("suficiencia.txt", true);

                    if (i == 1)
                    {
                        Escritura.WriteLine("ALUMNOS APTOS PARA PRUEBA DE SUFICIENCIA");
                        Escritura.WriteLine("  ");
                    }

                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.WriteLine("Nombre: " + alumno.Nombre);
                    Escritura.WriteLine("Carnet: " + alumno.Carnet);
                    Escritura.WriteLine("Nota global: " + alumno.NotaGlobal);
                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.Close();
                }
                else
                {
                    StreamWriter Escritura = new StreamWriter("desaprovados.txt", true);

                    if (i == 1)
                    {
                        Escritura.WriteLine("ALUMNOS DESAPROVADOS");
                        Escritura.WriteLine("  ");
                    }

                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.WriteLine("Nombre: " + alumno.Nombre);
                    Escritura.WriteLine("Carnet: " + alumno.Carnet);
                    Escritura.WriteLine("Nota global: " + alumno.NotaGlobal);
                    Escritura.WriteLine("-----------------------------------------");
                    Escritura.Close();
                }
            }

            MostrarMenu();
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Agregar 10 alumnos a archivos.");
            Console.WriteLine("2 - Abrir archivo aprovados en Notepad.");
            Console.WriteLine("3 - Imprimir aprobados, reprobados o suficiencia.");
            Console.WriteLine("4 - Salir");
            opcionMenu = int.Parse(Console.ReadLine());
        }

        static void AbrirAprovadosNotePad()
        {
            StartProcess(aprovados);
            opcionMenu = 4;
        }

        static void ElegirOpcion()
        {
            Console.Clear();
            Console.WriteLine("Que archivo desea abrir?.");
            Console.WriteLine("1 - Archivo aprovados.");
            Console.WriteLine("2 - Archivo desaprovados.");
            Console.WriteLine("3 - Archivo suficiencia");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                StartProcess(aprovados);
                opcionMenu = 4;
            }
            else if (opcion == 2)
            {
                StartProcess(desaprovados);
                opcionMenu = 4;
            }
            else
            {
                StartProcess(suficiencia);
                opcionMenu = 4;
            }


        }

        static void StartProcess(string archivo)
        {
            Process.Start("notepad.exe", archivo);
        }
    }
}
