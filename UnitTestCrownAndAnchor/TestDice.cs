using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using CrownAndAnchorGame;

namespace UnitTestCrownAndAnchor
{
    [TestClass]
    public class TestDice
    {
        [TestMethod]
        public void TestStringRepr()
        {
            string expected = "Crown";
            string actual = Dice.stringRepr(DiceValue.CROWN);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCurrentValueRepr()
        {
            Dice d1 = new Dice();
            string expected = Dice.stringRepr(d1.CurrentValue);
            string actual = d1.CurrentValueRepr;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRandomValue()
        {
            Dictionary<DiceValue, int> countMap =
                new Dictionary<DiceValue, int>() { 
                    { DiceValue.CROWN,0}, 
                    { DiceValue.ANCHOR,0}, 
                    { DiceValue.HEART,0}, 
                    { DiceValue.DIAMOND,0}, 
                    { DiceValue.CLUB,0}, 
                    { DiceValue.SPADE,0}, 
                };
            for (int i = 0; i < 100; i++)
            {
                countMap[Dice.RandomValue] += 1;
            }
            foreach (DiceValue dv in Enum.GetValues(typeof(DiceValue)))
            {
                if (countMap[dv] == 0)
                {
                    Assert.Fail("random didn't generate all values");
                }
            }
        }

        [TestMethod]
        public void TestRoll()
        {
            Dictionary<DiceValue, int> countMap =
                new Dictionary<DiceValue, int>() { 
                    { DiceValue.CROWN,0}, 
                    { DiceValue.ANCHOR,0}, 
                    { DiceValue.HEART,0}, 
                    { DiceValue.DIAMOND,0}, 
                    { DiceValue.CLUB,0}, 
                    { DiceValue.SPADE,0}, 
                };
            Dice d1 = new Dice();
            for (int i = 0; i < 100; i++)
            {
                d1.roll();
                countMap[d1.CurrentValue] += 1;
            }
            foreach (DiceValue dv in Enum.GetValues(typeof(DiceValue)))
            {
                if (countMap[dv] == 0)
                {
                    Assert.Fail("random didn't generate all values");
                }
            }
        }


    }
}
