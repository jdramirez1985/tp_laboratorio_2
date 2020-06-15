using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region "Campos"
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region "Constructores"
        Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region "Propiedades"
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Publica los datos completo de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            s.AppendFormat("CLASE DE: {0} POR {1}\n", this.clase, this.instructor.ToString());
            s.AppendLine("ALUMNOS\n");
            foreach (Alumno item in this.alumnos)
            {
                s.AppendLine(item.ToString());
            }
            s.AppendLine("<------------------------------------------------------------------>");
            return s.ToString();
        }
        /// <summary>
        /// Lee una Jornada guardada como archivo texto y lo retorna como string
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto t = new Texto();  
            string datos = "", archivo = "Jornada.txt";
            try
            {
                if (t.Leer(archivo, out datos))
                    return datos;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return datos;
        }
        /// <summary>
        /// Guarda todos los datos de la Jornada en archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            string archivo = "Jornada.txt";

            try
            {
                return t.Guardar(archivo, jornada.ToString());

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Una Jornada es igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.clase;
        }
        /// <summary>
        /// Una Jornada es diferente a un Alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Se puede agregar un alumno solo si este no se encuentra en la Jornada y si toma la clase de Jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                foreach (Alumno item in j.alumnos)
                {
                    if (item == a)
                        return j;
                }
            }
            j.alumnos.Add(a);

            return j;
        }
        #endregion

    }
}
