using System;

namespace AbcGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Games g = new Games (new int[]{-1, 1}, 10, "abcdefghijklmnopqrstuvwxyz");
            View v = new View ();
            v.timer(3);
            g.startTimer();
            while(g.hasNext())
            {
                g.next();
                char guess = v.getGuess(g.getCurrentRelative(), g.getCurrentDirection());
                if(g.check(guess))
                {
                    v.correctMessage();
                }
                else
                {
                    v.incorrectMessage(g.getCurrentAnswer());
                }
            }
            g.endTimer();
            v.totalTime(g.getTotalTime(), g.getTotalCorrect(), g.getRounds());
        }
    }
}
