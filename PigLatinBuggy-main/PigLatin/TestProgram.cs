using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PigLatin
{
    public class TestingProgram
    {
        [Theory]
        [InlineData("apple")]
        [InlineData("heck")]
        [InlineData("strong")]
        [InlineData("tommy@email.com")]
        [InlineData("aardvark")]
        [InlineData("Tommy")]
        [InlineData("gym")]
        [InlineData("apple joy gym tommy@email.com strong")]
        public void TestingToPigLatin(string input)
        {
            //Arrange:
            string expected = "";
            string actual = "";


            //Act:
            switch (input)
            {
                case "apple":
                    expected = "appleway";
                    break;
                case "heck":
                    expected = "eckhay";
                    break;
                case "strong":
                    expected = "ongstray";
                    break;
                case "tommy@email.com":
                    expected = "tommy@email.com";
                    break;
                case "aardvark":
                    expected = "aardvarkway";
                    break;
                case "Tommy":
                    expected = "ommytay";
                    break;
                case "gym":
                    expected = "gym";
                    break;
                case "apple joy gym tommy@email.com strong":
                    expected = "appleway oyjay gym tommy@email.com ongstray";
                    break;
                default:
                    break;
            }

            actual = Program.ToPigLatin(input);

            //Assert:
            Assert.Equal(expected, actual);
        }
    }
}
