using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        /// <summary>
        /// Atributo donde se asigna el valor numerico a operar.
        /// </summary>
        private double numero;
        #endregion

        #region constructores
        /// <summary>
        /// Construsctor por default: asigna el valor 0 a numero.
        /// </summary>
        public Numero()
        {
            this.numero = (double)0;
        }
        /// <summary>
        /// Constructor recibe string para validar que sea un valor numerico antes de asignarlo a numero.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Constructor asigna el valor recibido al atributo numero.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad asigna el valor recibido previa validacion de que sea un valor numerico.
        /// </summary>
        private string SetNumero
        {
            set { this.numero = this.ValidarNumero(value); }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo valida que el string recibido contenga valores numericos y lo retorna en double, caso contrario retorna 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            if (decimal.TryParse(strNumero, out decimal resultado))
                retorno = (double)resultado;
            else
                retorno = 0;

            return retorno;
        }
        /// <summary>
        /// Operador + realiza operacion suma entre dos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Operador - realiza operacion resta entre dos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Operador * realiza operacion multiplicacion entre dos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Operador / realiza operacion division siempre y cuando los dos operandos sean diferentes a 0
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n1.numero != 0 && n2.numero != 0)
                return n1.numero / n2.numero;
            else
                return double.MinValue;
        }
        /// <summary>
        /// Realiza conversión de Binario a Decimal 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            string strRetorno = "nada";
            int resultadoOperacion = 0, j = 0;
            decimal validar = 0;

            if (decimal.TryParse(binario, out validar))
                validar = Math.Truncate(validar); //convertir a decimal y obtener parte entera, otra forma es conv. explicita a int
            if (validar < 0)  // obtener valor absoluto en caso de ser un valor negativo
                validar = validar * -1;
            binario = validar.ToString(); // asignarlo a 'binario' nuevamente para hacer la operación de conversión

            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (binario.Substring(i, 1) == "0")
                    resultadoOperacion += 0;
                else if ((binario.Substring(i, 1) == "1"))
                    resultadoOperacion += (int)Math.Pow(2, j);
                else
                    return "Valor inválido";
                j++;
            }

            strRetorno = resultadoOperacion.ToString();
            return strRetorno;
        }
        /// <summary>
        /// Realiza conversión de Decimal a Binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string strNumero = "";
            int modulo;
            string strRetorno = "";
            if (numero < 0) 
                numero = numero * -1; // para obtener el valor absoluto si es negativo o sea menor a 0
            if (numero != 0)
            {
                while (numero > 0)
                {
                    modulo = (int)numero % 2;
                    numero = (numero - modulo) / 2;
                    if (modulo == 0)
                        strNumero += "0";
                    else
                        strNumero += "1";
                }
                for (int i = (strNumero.Length - 1); i >= 0; i--)
                {
                    strRetorno += strNumero.Substring(i, 1);
                }
            }
            else
                return "Valor invalido";
            
            return strRetorno;
        }
        /// <summary>
        /// Realiza conversión de Decimal a Binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            decimal.TryParse(numero, out decimal rs); 
            //rs = Math.Truncate(rs); // otra forma para obtener valor entero de double
            int rsi = (int)rs;        // para obtener el valor entero del double, perdiendo datos despues de la coma
            numero = rsi.ToString();
            if (double.TryParse(numero, out double result))
                return this.DecimalBinario(result);
            else
                return "Valor inválido";
        }
        #endregion
    }
}
