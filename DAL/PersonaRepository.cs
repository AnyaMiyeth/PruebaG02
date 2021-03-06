﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entity;
namespace DAL
{
    public class PersonaRepository
    {
        private string ruta = @"Persona.txt";
        private IList<Persona> personas;
        public PersonaRepository()
        {
            personas = new List<Persona>();
        }
        public void Guardar(Persona persona)
        
        {
            FileStream fileStream = new FileStream(ruta,FileMode.Append);
            StreamWriter stream = new StreamWriter (fileStream);
            stream.WriteLine(persona.ToString());
            stream.Close();
            fileStream.Close();
            
        }

        public IList<Persona> Consultar()
        {
            personas.Clear();
            
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(fileStream);
            string linea = string.Empty;
            while((linea=lector.ReadLine())!=null)
            {
                Persona persona = new Persona();
                string[] datos = linea.Split(';');
                persona.Identificacion = datos[0];
                persona.Nombre = datos[1];
                persona.Edad = int.Parse(datos[2]);
                persona.Sexo = datos[3];
                persona.Pulsacion = Convert.ToDecimal(datos[4]);
                personas.Add(persona);
            }
            fileStream.Close();
            lector.Close();
            return personas;
        }


        public void Eliminar(string identificacion)
        {
            personas.Clear();
            personas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in personas)
            {
                if (item.Identificacion!=identificacion)
                {
                    Guardar(item);
                }
            }

        }

        public void Modificar(Persona persona)
        {
            personas.Clear();
            personas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in personas)
            {
                if (item.Identificacion != persona.Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(persona);
                }
            }

        }

        public Persona Buscar(string identificacion) 
        {
            personas = Consultar();
           return personas.Where(p=>p.Identificacion==identificacion).FirstOrDefault();
        }


        
    }
}
