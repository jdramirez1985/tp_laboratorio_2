using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region "Campos"
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Solo constructor estático inicializa random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Inicializa random y la cola de EClases
        /// </summary>
        /// 
        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Asigna dos clases random a la cola de EClases de Profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, Enum.GetNames(typeof(Universidad.EClases)).Length - 1));
            }
        }

        /// <summary>
        /// Devuelve el detalle de todas las clases que dá el Profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("CLASES DEL DÍA: ");
            foreach (var item in this.clasesDelDia)
            {
                s.AppendLine(item.ToString());
            }
            return s.ToString();
        }

        /// <summary>
        /// Un Profesor es igual a una EClase si la dá (contiene en su Queue)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (var item in i.clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Un Profesor es diferente a una EClase si no dá la misma
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Muestra todos los datos de Profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(base.MostrarDatos());
            s.AppendLine(this.ParticiparEnClase());
            return s.ToString();
        }

        /// <summary>
        /// Publica todos los datos de Profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
