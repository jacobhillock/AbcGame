using System;

namespace AbcGame
{
    public class View
    {
        public View()
        {}

        public char getGuess (char letter, int dir)
        {
            if(dir < 0)
            {
                Console.Write("Guess letter {0} before {1}: ", dir*-1, letter);
            }
            else if(dir > 0)
            {
                Console.Write("Guess letter {0} after {1}: ", dir, letter);
            }
            return Console.ReadLine()[0];
        }

        public void correctMessage()
        {
            Console.WriteLine("Correct!");
        }

        public void incorrectMessage()
        {
            Console.WriteLine("Incorrect..");
        }

        public void incorrectMessage(char correct)
        {
            Console.WriteLine("Incorrect.. Correct Letter was: {0}", correct);
        }

        public void totalTime(decimal time)
        {
            Console.WriteLine("Total time was: {0}", time);
        }
        public void totalTime(decimal time, int correct)
        {
            Console.WriteLine("Total time was: {0} with {1} correct", time, correct);
        }
        public void totalTime(decimal time, int correct, int total)
        {
            Console.WriteLine("Total time was: {0}. You score was {1} out of {2}", time, correct, total);
        }

        public void timer(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write("{0}... ", i);
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("GO!");
        }
    }

}