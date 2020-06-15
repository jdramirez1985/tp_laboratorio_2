using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region "Campos"
        private int legajo;
        #endregion

        #region "Constructores"
        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Métodos"
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Muestra todos los datos de Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder s = new StringBuilder();

            s.AppendLine(base.ToString());
            s.AppendFormat("LEGAJO: {0}", this.legajo.ToString());

            return s.ToString();
        }
        /// <summary>
        /// Dos Universitarios son iguales si son del mismo tipo y su legajo o DNI son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2))
            {
                if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Dos Universitarios son diferentes si no son del mismo tipo y su legajo o DNI son diferentes
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Universitario: Son iguales si son del mismo Tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
                return true;
            else
                return false;
        }
        #endregion
    }
}
