namespace SkalProj_Datastrukturer_Minne.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TestQueue()
        {
            //Arrange

            //a.ICA öppnar och kön till kassan är tom
            Queue<string> queueTillKassaICA = new Queue<string>();

            queueTillKassaICA.Enqueue("Kalle");//b.Kalle ställer sig i kön
            queueTillKassaICA.Enqueue("Greta");//c.Greta ställer sig i kön
            queueTillKassaICA.Dequeue();//d.Kalle blir expedierad och lämnar kön
            queueTillKassaICA.Enqueue("Stina");//e.Stina ställer sig i kön
            queueTillKassaICA.Dequeue();//f.Greta blir expedierad och lämnar kön
            queueTillKassaICA.Enqueue("Olle");//g.Olle ställer sig i kön

            int fourPeoplesInQueue = 2;
            //string kallefirstInQueue = "Kalle"; TEST FAIL
            string stinaFirstInQueue = "Stina"; //TEST PASS

            //Act
            int numberOfPeoplesInQueue = queueTillKassaICA.Count;
            string firstInQueueICA = queueTillKassaICA.FirstOrDefault()!;
            //Assert
            Assert.Equal(fourPeoplesInQueue, numberOfPeoplesInQueue);
            //Assert.Equal(kallefirstInQueue, firstInQueueICA); TEST FAIL
            //Assert.True(firstInQueueICA.Any()); TEST PASS
            Assert.Equal(stinaFirstInQueue, firstInQueueICA);
        }
        [Fact]
        public void TestReverseText()
        { 
        
        }
        [Theory]
        [InlineData (true, "(())")]
        [InlineData(true, "{}")]
        [InlineData(true, "[({})]")]
        [InlineData(true, "List<int> list = new List<int>() { 1, 2, 3, 4 };")]
        /*
        * CheckParanthesis: method to check if the paranthesis in a string is Correct or incorrect.
        * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
        */
        public void TestCheckParanthesis_TrueCases(bool expectedResult, string expectedString)
        {
            //Arrange
            //Act
            // Not developed yet.
            throw new NotImplementedException();
            //Assert
            //Assert.Equal(expectedResult, actualResult);

        }
        [Theory]
        [InlineData(false, "(()])")]
        [InlineData(false, "[)")]
        [InlineData(false, "{[()}]")]
        [InlineData(false, "List<int> list = new List<int>() { 1, 2, 3, 4 );")]
        /*
        * CheckParanthesis: method to check if the paranthesis in a string is Correct or incorrect.
        * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
        */
        public void TestCheckParanthesis_FalseCases(bool expectedResult, string expectedString)
        {
            //Arrange
            //Act
            // Not developed yet.
            throw new NotImplementedException();
            //Assert
            //Assert.Equal(expectedResult, actualResult);

        }
    }
}