using System;
using System.Collections;


namespace TrueTabla
{   
    partial class Program
    {   
        static int exp(int pBase, int pPot)
        {
            if(pPot == 0)
            {
                return 1;
            }else
            {
                return pBase * exp( pBase, pPot-1);
            }
        }

        static void CatchPropS( Queue pPropQueue)
        {
            String _bitPropName = " ";
            int _i = 1;
            while( _bitPropName != "")
            {
                Console.Write("Proposiosion #"+_i+": ");
                _bitPropName = Console.ReadLine();
                Console.Clear();
                if( _bitPropName != "")
                {
                    pPropQueue.Enqueue( new Prop( _bitPropName));
                    _i++;
                }
            }
        }

        static void AutoLlenarPropS( Queue pPropQueue)
        {   
            Prop _bitProp;
            for(int i=0; i<pPropQueue.Count; i++)
            {
                _bitProp = (Prop) pPropQueue.Dequeue();
                _bitProp.AutoLlenar( exp( 2, (pPropQueue.Count+1)), exp( 2, (pPropQueue.Count+1)-( i+1)));
                pPropQueue.Enqueue( _bitProp);
            }
        }

        static void PrintProp( Queue pPropQueue)
        {   
            Prop _bitProp;
            for( int iProp=0; iProp < pPropQueue.Count; iProp++)
            {
                _bitProp = (Prop) pPropQueue.Dequeue();
                Console.Write("  " + _bitProp.letra + "\t");
                pPropQueue.Enqueue( _bitProp);
            }
            Console.Write("\n");
            for( int iTruth=0; iTruth < exp( 2, pPropQueue.Count); iTruth++)
            {   
                for( int iProp=0; iProp < pPropQueue.Count; iProp++)
                {   
                    _bitProp = (Prop) pPropQueue.Dequeue();
                    if(_bitProp.Tverdad[iTruth])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write( (_bitProp.Tverdad[iTruth] + " ") + " | ");
                        Console.ResetColor();
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(_bitProp.Tverdad[iTruth] + " | ");
                        Console.ResetColor();
                    }
                    pPropQueue.Enqueue( _bitProp);
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {   
            Console.Clear();
            
            /*
            Prop[] AproposicionesS = CatchPropS();
            AutoLlenarPropS( AproposicionesS);
            PrintProp( AproposicionesS);
            */

            //step 1: insertar las proposiciones simples
            Queue QproposicionesS = new Queue();
            CatchPropS( QproposicionesS);
            AutoLlenarPropS( QproposicionesS);
            PrintProp( QproposicionesS);
        }
    }
}
