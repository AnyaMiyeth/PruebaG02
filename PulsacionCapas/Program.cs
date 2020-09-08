using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;
namespace PulsacionCapas
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonaService personaService = new PersonaService();
            Guardar(personaService);
            Consulta(personaService);
            Eliminar(personaService);
            Consulta(personaService);
            Modificar(personaService);
            Consulta(personaService);
            Console.ReadKey();
        }

        private static void  Modificar(PersonaService personaService)
        {
            string mensaje;
            Persona persona4 = new Persona()
            {
                Identificacion = "3",
                Nombre = "Pedro",
                Sexo = "M",
                Edad = 20

            };
            persona4.CalcularPulsacion();
            mensaje = personaService.Modificar(persona4);
            Console.WriteLine(mensaje);
        }

        private static void Eliminar(PersonaService personaService)
        {
            string mensaje;
            Console.WriteLine("Digite el Identificacion de la persona a eliminar");
            string identificacion = Console.ReadLine();
            mensaje = personaService.Eliminar(identificacion);
            Console.WriteLine(mensaje);
           
        }

        private static void Guardar(PersonaService personaService)
        {
            string mensaje;
            Persona persona1 = new Persona()
            {
                Identificacion = "1",
                Nombre = "Juan",
                Sexo = "M",
                Edad = 40,

            };
            persona1.CalcularPulsacion();

            Persona persona2 = new Persona()
            {
                Identificacion = "2",
                Nombre = "Maria",
                Sexo = "F",
                Edad = 23

            };
            persona2.CalcularPulsacion();

            Persona persona3 = new Persona()
            {
                Identificacion = "3",
                Nombre = "Mario",
                Sexo = "M",
                Edad = 15

            };
            persona3.CalcularPulsacion();

            mensaje = personaService.Guardar(persona1);
            Console.WriteLine(mensaje);
            Console.WriteLine(persona1.ToString());
            mensaje = personaService.Guardar(persona2);
            Console.WriteLine(mensaje);
            Console.WriteLine(persona2.ToString());
            mensaje = personaService.Guardar(persona3);
            Console.WriteLine(mensaje);
            Console.WriteLine(persona3.ToString());
            mensaje = personaService.Guardar(persona1);
            Console.WriteLine(mensaje);
            Console.WriteLine(persona1.ToString());
           
        }

        private static void Consulta(PersonaService personaService)
        {
            RespuestaConsulta respuestaConsulta = personaService.Consultar();
            Console.WriteLine(respuestaConsulta.Mensaje);
            if (!respuestaConsulta.Error)
            {
                foreach (var item in respuestaConsulta.Personas)
                {
                    Console.WriteLine(item.ToString());
                }
            }
           
        }
    }
}
