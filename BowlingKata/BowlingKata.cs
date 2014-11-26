using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata
{
   

    [TestClass]
    public class BowlingGameTest
    {
        private Game g;

        [TestInitialize]
        public void TestSetUp()
        {
            g = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }


        [TestMethod]
        public void Test_GutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }


        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }


        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(3);

            RollMany(17, 0);
            Assert.AreEqual(16, g.Score());
        }


        [TestMethod]
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(3);
            g.Roll(4);

            RollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }


        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, g.Score());
        }


        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }



    /*
    * 
    * The game consists of 10 frames.  In each frame the player has
       two opportunities to knock down 10 pins.  The score for the frame is the total
       number of pins knocked down, plus bonuses for strikes and spares.

       A spare is when the player knocks down all 10 pins in two tries.  The bonus for
       that frame is the number of pins knocked down by the next roll.  So in frame 3
       above, the score is 10 (the total number knocked down) plus a bonus of 5 (the
       number of pins knocked down on the next roll.)

       A strike is when the player knocks down all 10 pins on his first try.  The bonus
       for that frame is the value of the next two balls rolled.

       In the tenth frame a player who rolls a spare or strike is allowed to roll the extra
       balls to complete the frame.  However no more than three balls can be rolled in
       tenth frame.

    * */
    public class Game
    {

        private int[] rolls = new int[21];
        private int currentRoll = 0;

        internal void Roll(int pins)
        {

            rolls[currentRoll++] = pins;
        }

        internal int Score()
        {
            int frameIndex = 0;
            int score = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }

            }
            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }
        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }
    }
}
