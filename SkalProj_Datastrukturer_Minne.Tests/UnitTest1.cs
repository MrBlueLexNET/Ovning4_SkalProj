namespace SkalProj_Datastrukturer_Minne.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TestQueue()
        {
            //Arrange

            //a.ICA �ppnar och k�n till kassan �r tom
            Queue<string> queueTillKassaICA = new Queue<string>();

            queueTillKassaICA.Enqueue("Kalle");//b.Kalle st�ller sig i k�n
            queueTillKassaICA.Enqueue("Greta");//c.Greta st�ller sig i k�n
            queueTillKassaICA.Dequeue();//d.Kalle blir expedierad och l�mnar k�n
            queueTillKassaICA.Enqueue("Stina");//e.Stina st�ller sig i k�n
            queueTillKassaICA.Dequeue();//f.Greta blir expedierad och l�mnar k�n
            queueTillKassaICA.Enqueue("Olle");//g.Olle st�ller sig i k�n

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
    }
}