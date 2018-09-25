using System;
using System.Collections;

/// <summary>  
///  This class performs an important function.  
/// </summary>

namespace CardsGO
{
    class Program
    {   
        public static string PrintCard(Card pCard)
        {   
            string _return = "";
            if(pCard.figure[0] == pCard.value[0])
            {
                _return += "JOKER";
            }else
            {
                for (int i = 0; i < 2; i++)
                {
                    _return += pCard.value[i];
                }
                _return+='_';
                for (int i = 0; i < 2; i++)
                {
                    _return += pCard.figure[i];
                }
            }

            Console.Write(_return+"\n");
            return _return;
        }
        public static void CrearNaipes(Stack pProtoNaipes)
        {
            string[] _values = new string[] 
            { "02", "03", "04", "05", "06", "07", "08",
            "09", "10", "JJ", "QQ", "KK", "AA"};
            string[] _figures = new string[] 
            { "TR", "PI", "DI", "CO"};
            for (int _cFigures = 0; _cFigures < _figures.Length; _cFigures++)
            {
                for (int _cValues = 0; _cValues < _values.Length; _cValues++)
                {
                    Card bit = new Card(
                        _values[ _cValues],
                        _figures[ _cFigures]
                    );
                    pProtoNaipes.Push( bit);
                }
            }
            pProtoNaipes.Push(new Card( "jk","jk"));
            MixNaipes( pProtoNaipes);
            Console.WriteLine("naipes ordenados ;)");
        }
        public static void MixNaipes( Stack pNaipes)
        {
            Stack _copy = new Stack();
            Random _ran = new Random();
            int _r;
            //Console.WriteLine("quedan "+_copy.Count+"naipes");
            while(pNaipes.Count > 0)
            {
                _r = _ran.Next(1,pNaipes.Count);
                if(_r >= 1)
                {
                    _copy.Push( CatchCard( pNaipes, _r));
                    //Console.WriteLine("quedan "+_copy.Count+"naipes");
                }else
                {
                    _copy.Push((Card) pNaipes.Pop());
                    //Console.WriteLine("quedan "+_copy.Count+"naipes");
                }
            }
            int _n = _copy.Count;
            for(int i=0; i<_n; i++)
            {   
                pNaipes.Push((Card) _copy.Pop());
            }
        }
        public static Card CatchCard( Stack pNaipes, int ran)
        {   
            Card _rCard = new Card();
            Stack _copy = new Stack();
            for(int i=0; i<ran-1; i++)
            {   
                _copy.Push((Card) pNaipes.Pop());
            }
            _rCard = (Card) pNaipes.Pop();
            for(int i=0; i<ran-1; i++)
            {   
                pNaipes.Push((Card) _copy.Pop());
            }
            return _rCard;
        }
        public static ConsoleColor captureColor()
        {   
            Console.WriteLine("--color del jugador--\n(colores disponibles, default blanco):"+
                "\n1.Azul"+"\n2.Cyan"+"\n3.Gris"+"\n4.Verde"+
                "\n5.Magenta"+"\n6.Rojo"+"\n7.Blanco"+"\n8.Amarillo"
            );
            char option = char.Parse(Console.ReadLine());
            ConsoleColor _return;
            switch(option)
            {
                case '1':
                    _return = ConsoleColor.Blue;
                    break;
                case '2':
                    _return = ConsoleColor.Cyan;
                    break;
                case '3':
                    _return = ConsoleColor.Gray;
                    break;
                case '4':
                    _return = ConsoleColor.Green;
                    break;
                case '5':
                    _return = ConsoleColor.Magenta;
                    break;
                case '6':
                    _return = ConsoleColor.Red;
                    break;
                case '8':
                    _return = ConsoleColor.Yellow;
                    break;
                case '7':
                default:
                    _return = ConsoleColor.White;
                    break;
            }
            return _return;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! :D");
            Stack maso = new Stack();
            Queue trash = new Queue();
            Queue Players = new Queue();
            CrearNaipes( maso);
            int _n = maso.Count;

            for(int i=0; i<_n; i++)
            {
                Console.Write("carta #"+(i+1)+" : ");PrintCard((Card) maso.Pop());
            }
        }
    }
}
