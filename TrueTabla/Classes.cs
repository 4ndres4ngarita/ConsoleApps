using System;

namespace TrueTabla
{
	public class Conector
    {
        public char tipo;

        public Conector()
        {
            this.tipo = '\0';
        }

        public Conector(char pTipo)
        {
            this.tipo = pTipo;
        }

        public bool conjugar(bool exp)
        {
            return !exp;
        }

        public bool conjugar(bool exp1, bool exp2)
        {   
            bool _return = false;
            switch(this.tipo)
            {
                case '^':
                    _return = (exp1 && exp2);
                    break;
                case 'º':
                    _return = (exp1 || exp2);
                    break;
                case '*':
                    _return = exp1 != exp2;
                    break;
                case '>':
                    _return = exp1 ? exp2 : true;
                    break;
                case '<':
                    _return = (exp1 && exp2) || ( exp1==false && exp2==false); 
                    break;
            }
            return _return;
        }
    }

    public class Prop
    {
        public string letra;
        public bool[] Tverdad;

        public Prop( string pLetra = "")
        {
            this.letra = pLetra;
        }

        public Prop( int pN_Tverdad)
        {
            this.letra = "";
            this.Tverdad = new bool[ pN_Tverdad];
        }

        public void AutoLlenar(int n_Filas, int paso)
        {
            Tverdad = new bool[n_Filas];
            int cambio = 0, i = 0;
            while(i < n_Filas)
            {
                while(cambio < paso)
                {
                    this.Tverdad[i] = true;
                    i++;
                    cambio++;
                }
                while(cambio > 0)
                {
                    this.Tverdad[i] = false;
                    i++;
                    cambio--;
                }
            }
        }

    }
}