using Xunit;
using Yatzy;
using Moq; 

namespace YatzyTest
{
    public class DieTest
    {
        [Fact]
        public void DiceShouldReturnValueWhenRolled()
        {
            var die = new Die();
            var mock = new Mock<IRng>();
            mock.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            die.Roll(mock.Object); 
            var value = die.Value;
            Assert.Equal(1, value);
        }
        
        [Fact]
        public void DiceShouldChangeValueWhenRolledAgain()
        {
            var die = new Die();
            var mock = new Mock<IRng>();
            mock.SetupSequence(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(4).Returns(1);            
            die.Roll(mock.Object);
            die.Roll(mock.Object);
            var value = die.Value;
            Assert.Equal(1, value);
        }
    }
}