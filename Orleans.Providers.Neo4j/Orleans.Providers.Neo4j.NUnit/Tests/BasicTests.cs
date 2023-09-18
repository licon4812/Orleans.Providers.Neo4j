using Orleans.Providers.Neo4j.NUnit.Classes;
using Orleans.Providers.Neo4j.NUnit.Grains;

namespace Orleans.Providers.Neo4j.NUnit.Tests
{
    public class BasicTests
    {
        private TestOrleansCluster _testCluster;
        private TestContainers _testContainers;

        [OneTimeSetUp]
        public async Task SetupAsync()
        {
            _testCluster = new TestOrleansCluster();
            _testContainers = new TestContainers();
            await _testContainers.CreateNeo4jContainerAsync();
            await _testCluster.BuildAsync();
        }

        [Test]
        public async Task SimpleSetAndGet()
        {
            var nicholasCage = _testCluster.GetGrain<IActorGrain>("nickolasCage");
            await nicholasCage.SetName("Nicholas Cage");

            var title = await nicholasCage.GetName();
            title.ShouldBe("Nicholas Cage");
        }
    }
}