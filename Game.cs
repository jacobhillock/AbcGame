using System;

namespace AbcGame
{
    public class Games
    {
        // Class setting variables
        int[] availableDirections;
        int rounds;
        string alphabet;

        // Game using variables
        int current;
        int totalCorrect;
        char[] relatives;
        char[] answers;
        int[] directions;

        // Timer functionality
        long timerStart;
        long timerEnd;
        public Games (int[] availableDirections, int rounds, string alphabet)
        {
            this.availableDirections = availableDirections;
            this.rounds = rounds;
            this.alphabet = alphabet;
            this.generate();
        }

        public void generate()
        {
            // initialize game variables
            this.relatives = new char[this.rounds];
            this.answers = new char[this.rounds];
            this.directions = new int[this.rounds];
            this.current = -1;
            this.totalCorrect = 0;

            // clear timers
            this.timerStart = 0;
            this.timerEnd = 0;

            Random rnd = new Random((int)DateTimeOffset.Now.ToUnixTimeMilliseconds());
            int lengthAlpha = this.alphabet.Length;
            for(int i = 0; i < this.rounds; i++)
            {
                int dir = this.availableDirections[rnd.Next(this.availableDirections.Length)];
                if (dir < 0)
                {
                    this.relatives[i] = (char)(rnd.Next(lengthAlpha + dir) + 97 - dir);
                }
                else if (dir > 0)
                {
                    this.relatives[i] = (char)(rnd.Next(lengthAlpha - dir) + 97);
                }

                this.answers[i] = (char)((int)this.relatives[i] + dir);
                this.directions[i] = dir;
            }
        }

        public void next()
        {
            this.current = this.current + 1;
        }

        public bool hasNext()
        {
            return !(this.current + 1 >= this.rounds);
        }

        public char getCurrentRelative()
        {
            if (this.current == -1 || this.current >= this.rounds)
            {
                return '_';
            }
            return this.relatives[this.current];
        }

        public char getCurrentAnswer()
        {
            if (this.current == -1 || this.current >= this.rounds)
            {
                return '_';
            }
            return this.answers[this.current];
        }

        public int getCurrentDirection()
        {
            if (this.current == -1 || this.current >= this.rounds)
            {
                return 0;
            }
            return this.directions[this.current];
        }

        public bool check(char guess)
        {
            if (guess == this.answers[this.current])
            {
                this.totalCorrect = this.totalCorrect + 1;
                return true;
            }
            return false;
        }

        public void startTimer()
        {
            this.timerStart = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void endTimer()
        {
            this.timerEnd = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public decimal getTotalTime()
        {
            if (this.timerStart > this.timerEnd)
            {
                return 0m;
            }

            return (this.timerEnd-this.timerStart)/1000m;
        }

        public int getTotalCorrect()
        {
            return this.totalCorrect;
        }

        public int getRounds()
        {
            return this.rounds;
        }
    }

}