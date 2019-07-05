using System.Collections.Generic;
using Xunit;

namespace ListOfCombination
{
    public class Tests
    {
        //[Fact]
        //public static List<int> GetNumbersTest()
        //{
        //    List<int> numListTest = new List<int> { 1, 2, 3, 4, 5, 6 };
        //    List<int> actual = new List<int>();
        //    actual = Program.GetNumbers();
        //    Assert.Equal(numListTest, actual);
        //    return actual;
        //}

        [Fact]
        public void CreateCombinationsTest()
        {
            List<int> testInput = new List<int>{1,2,3,4,5,6};
            List<string>expected =new List<string> {"1,2,3,4,5,6"};
            List<string> actual = Program.CreateCombinations(testInput);
            Assert.Equal(expected, actual);

        }
    }
}
