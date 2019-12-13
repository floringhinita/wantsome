namespace UnitTests
{
    using Xunit;

    public class PensionServiceV2UnitTests
    {
        [Fact]
        public void PersonWithAge38_ShouldNotHavePensionAndShouldNotBeNotified()
        {
        }

        [Fact]
        public void PersonWithAge42_ShouldNotHavePensionAndShouldBeNotified()
        {
        }

        [Fact]
        public void PersonWithAge52_ShouldHavePensionAndShouldBeNotified()
        {
        }
    }
}
