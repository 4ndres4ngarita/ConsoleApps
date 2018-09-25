using System;
using System.Collections;
namespace CardsGO
{   
    
    public struct Card
    {
        public char[] value;
        public char[] figure;
        public ConsoleColor color;
        public Card(string pValue, string pFigure = null, ConsoleColor pColor = ConsoleColor.White)
        {
            this.value = pValue.ToCharArray();
            this.figure = pFigure.ToCharArray();
            this.color = pColor;
        }
        public Card(char[] pValue, char[] pFigure, ConsoleColor pColor = ConsoleColor.White)
        {
            this.value = pValue;
            this.figure = pFigure;
            this.color = pColor;
        }
    }
    public class Player
    {   
        public string name;
        public int lives;
        public ConsoleColor color;
        public Stack baraja = new Stack();
        public Player( string pName = "UnKnow", int pLives = 0, ConsoleColor pColor = ConsoleColor.White)
        {
            this.name = pName;
            this.lives = pLives;
            this.color = pColor;
        }
        public void GiveCard(Card pCard)
        {   
            this.baraja.Push(pCard);
        }
        public void GiveBaraja(Card[] pBaraja, int _n)
        {   
            for(int i = 0; i < _n; i++)
            {
                this.baraja.Push(pBaraja[i]);
            }
        }
        public int GetCardsCant()
        {   
            int _return = this.baraja.Count;
            
            return _return;
        }
        public Card[] ShowCards()
        {
            Card[] cards = new Card[this.GetCardsCant()];
            for(int i=0; i<this.GetCardsCant(); i++)
            {
                cards[i] = (Card) this.baraja.Pop();
                this.baraja.Push(cards[i]);
            }
            return cards;
        }
    }
    /*
        
        */
        
}