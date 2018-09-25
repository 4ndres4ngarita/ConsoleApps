using System;

namespace TrueTabla
{
	partial class Program
    {
    	static void AutoLlenarPropS( Prop[] pPropVector)
        {
            for(int i=0; i<pPropVector.Length; i++)
            {
                pPropVector[i].AutoLlenar( exp( 2, pPropVector.Length), exp( 2, pPropVector.Length-( i+1)));
            }
        }

		static Prop[] CatchPropS()
        {   
            Prop[] _return;
            Console.Write("Digite numero de Proposiosiones Simples: ");
            _return = new Prop[ int.Parse( Console.ReadLine()) ];
            for( int i=0; i<_return.Length; i++)
            {
                Console.Write("Proposiosion #"+(i+1)+": ");
                _return[i] = new Prop( Console.ReadLine());
            }
            return _return;
        }

		static void PrintProp( Prop[] pPropVector)
        {
            for( int iProp=0; iProp < pPropVector.Length; iProp++)
            {
                Console.Write
                    (
                        "  " + pPropVector[iProp].letra + "\t"
                    );
            }
            Console.Write("\n");
            for( int iTruth=0; iTruth < pPropVector[0].Tverdad.Length; iTruth++)
            {
                for( int iProp=0; iProp < pPropVector.Length; iProp++)
                {   
                    string _message = Convert.ToString(pPropVector[iProp].Tverdad[iTruth]);
                    if(pPropVector[iProp].Tverdad[iTruth])
                    {
                        _message +=" ";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(_message + " | ");
                        Console.ResetColor();
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(_message + " | ");
                        Console.ResetColor();
                    }
                    
                }
                Console.Write("\n");
            }
        }
    }
}