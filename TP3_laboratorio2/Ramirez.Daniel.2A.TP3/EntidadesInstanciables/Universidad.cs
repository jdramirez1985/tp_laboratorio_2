using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region "Campos"
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;
        #endregion

        #region "Constructores"
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region "Propiedades"
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Serializa y guarda una Universidad en xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string archivo = "Universidad.xml";
            try
            {
                return (xml.Guardar(archivo, uni));
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Deserializa Universidad en XML y devuelve un Universidad
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad u = new Universidad();
            string archivo = "Universidad.xml";
            try
            {
                if (xml.Leer(archivo, out u))
                    return u;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return u;
        }
        /// <summary>
        /// Muestra todos los datos de Universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("JORNADAS: \n");
            foreach (Jornada item in uni.jornada)
            {
                s.AppendLine(item.ToString());
            }
            return s.ToString();
        }
        /// <summary>
        /// Publica todos los datos de Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Una Universidad es igual a un Alumno si este se encuentra en la misma.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Una Universidad es igual a un Profesor si este se encuentra en la misma.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// La igualación entre un Universidad y una EClase retornará el primer Profesor capaz de dar esa clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// El distinto entre un Universidad y una EClase retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                    return p;
            }
            throw new ArgumentNullException();
        }
        /// <summary>
        /// Agrega una Jornada y asigna un Profesor que pueda dar la clase, caso contrario lanza SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = new Profesor();
            try
            {
                p = g == clase;
            }
            catch (SinProfesorException e)
            {
                throw e;
            }
            Jornada j = new Jornada(clase, p);
            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                    j += item;
            }
            g.jornada.Add(j);
            return g;
        }
        /// <summary>
        /// Agregar un Alumno si no se encuentra, caso contrario lanza AlumnoRepetidoException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            g.alumnos.Add(a);
            return g;
        }
        /// <summary>
        /// Agrega un Profesor solo si no se encuentra en la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g == i)
                return g;
            g.profesores.Add(i);
            return g;
        }

        #endregion

        #region "Tipos Anidados"
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
