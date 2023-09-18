using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.Entities
{
    public class Operacion
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            this.primerOperando = primerOperando;
            this.segundoOperando = segundoOperando;
        }
        public Numeracion Operar(char operador)
        {
            double resultado = 0.0;

            switch (operador)
            {
                case '+':
                    resultado = primerOperando.valorNumerico + segundoOperando.valorNumerico;
                    break;
                case '-':
                    resultado = primerOperando.valorNumerico - segundoOperando.valorNumerico;
                    break;
                case '*':
                    resultado = primerOperando.valorNumerico * segundoOperando.valorNumerico;
                    break;
                case '/':
                    if (segundoOperando.valorNumerico != 0) 
                    {
                        resultado = primerOperando.valorNumerico / segundoOperando.valorNumerico;
                    }
                    else
                    {
                        throw new ArgumentException("No se puede dividir por cero.");
                    }
                    break;
                default:
                    throw new ArgumentException("Operador no válido.");
            }

            return new Numeracion(ESistema.Decimal, resultado);
        }

        public Numeracion PrimerOperando
        {
            get { return primerOperando; }
            set { primerOperando = value; }
        }

        public Numeracion SegundoOperando
        {
            get { return segundoOperando; }
            set { segundoOperando = value; }
        }
    }

}
