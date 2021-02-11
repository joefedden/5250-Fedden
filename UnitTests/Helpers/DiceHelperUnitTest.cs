﻿using Mine.Models;
using NUnit.Framework;
using Mine.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class DiceHelperUnitTest
    {
        [Test]
        public void RollDice_Invalid_Roll_Zero_Should_Return_Zero()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 1);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDice_Valid_Roll_1_Dice_6_Should_Return_Between_1_And_6()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 6);

            // Reset

            // Assert
            Assert.AreEqual(true, result >= 1);
            Assert.AreEqual(true, result <= 6);
        }

        [Test]
        public void RollDice_Valid_Roll_1_Dice_10_Fixed_5_Should_Return_5()
        {
            // Arrange
            DiceHelper.ForceRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 5;

            // Act
            var result = DiceHelper.RollDice(1, 10);

            // Reset
            DiceHelper.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void RollDice_Valid_Roll_3_Dice_10_Fixed_5_Should_Return_15()
        {
            // Arrange
            DiceHelper.ForceRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 15;

            // Act
            var result = DiceHelper.RollDice(3, 10);

            // Reset
            DiceHelper.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(15, result);
        }
    }
}