﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        #region "Constructores"
        public Camioneta(Vehiculo.EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override Vehiculo.ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Grande;
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Publica datos de Camioneta
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
