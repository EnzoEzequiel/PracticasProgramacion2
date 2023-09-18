using System;

namespace Trabajo_Integrador.Entities
{
    public enum ESistema
    {
        Decimal,
        Binario
    }

    public class Numeracion
    {
        private ESistema sistema;
        public double valorNumerico;

        public Numeracion(ESistema sistema, double valorNumerico)
        {
            this.sistema = sistema;
            this.valorNumerico = valorNumerico;
        }

        public Numeracion(string valorNumerico, ESistema sistema)
        {
            this.sistema = sistema;
            InicializarValores(valorNumerico, sistema);
        }

        private void InicializarValores(string valor, ESistema sistema)
        {
            if (sistema == ESistema.Decimal)
            {
                if (!double.TryParse(valor, out valorNumerico))
                {
                    throw new ArgumentException("El valor no es un numero decimal valido.");
                }
            }
            else if (sistema == ESistema.Binario)
            {
                valorNumerico = BinarioDecimal(valor);
            }
        }

        public string ConvertirA(ESistema sistemaDestino)
        {
            if (sistema == sistemaDestino)
            {
                return valorNumerico.ToString();
            }

            if (sistema == ESistema.Decimal && sistemaDestino == ESistema.Binario)
            {
                return DecimalABinario(valorNumerico);
            }
            else if (sistema == ESistema.Binario && sistemaDestino == ESistema.Decimal)
            {
                return BinarioDecimal(valorNumerico.ToString()).ToString();
            }

            return string.Empty; 
        }

        private static bool EsBinario(string valor)
        {
            foreach (char c in valor)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }

            return true;
        }

        public string Sistema
        {
            get { return sistema.ToString(); }
        }

        public string Valor
        {
            get
            {
                if (sistema == ESistema.Decimal)
                {
                    return valorNumerico.ToString();
                }
                else if (sistema == ESistema.Binario)
                {
                    return valorNumerico.ToString();
                }
                return string.Empty;
            }
        }

        public static double BinarioDecimal(string valor)
        {
            if (!EsBinario(valor))
            {
                throw new ArgumentException("El valor no es un número binario válido.");
            }

            double resultado = 0;
            int longitud = valor.Length;
            int potencia = 0; 

            for (int i = longitud - 1; i >= 0; i--)
            {
                int bit = int.Parse(valor[i].ToString());
                resultado += bit * (1 << potencia);
                potencia++;
            }

            return resultado;
        }


        public static string DecimalABinario(string valor)
        {
            if (!double.TryParse(valor, out double valorDecimal))
            {
                throw new ArgumentException("El valor no es un número decimal válido.");
            }

            return DecimalABinario(valorDecimal);
        }

        public static string DecimalABinario(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("El valor debe ser un número decimal positivo.");
            }

            if (valor == 0)
            {
                return "0"; 
            }

            int parteEntera = (int)valor; 
            double parteDecimal = valor - parteEntera; 

            
            string binarioParteEntera = "";
            while (parteEntera > 0)
            {
                int residuo = parteEntera % 2;
                binarioParteEntera = residuo + binarioParteEntera;
                parteEntera /= 2;
            }
            
            string binarioParteDecimal = "";
            if (parteDecimal > 0)
            {
                binarioParteDecimal = ".";

                for (int i = 0; i < 32; i++) 
                {
                    parteDecimal *= 2;
                    int bit = (int)parteDecimal;
                    binarioParteDecimal += bit;
                    parteDecimal -= bit;
                    if (parteDecimal == 0)
                    {
                        break;
                    }
                }
            }
            return binarioParteEntera + binarioParteDecimal;
        }
    }
}
