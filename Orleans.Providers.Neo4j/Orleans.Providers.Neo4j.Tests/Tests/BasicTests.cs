using Orleans.Providers.Neo4j.Tests.Common;
using Orleans.Providers.Neo4j.Tests.Grains;

namespace Orleans.Providers.Neo4j.Tests.Tests
{
    public class BasicTests
    {
        private TestOrleansCluster _testCluster;

        [OneTimeSetUp]
        public async Task SetupAsync()
        {
            _testCluster = new TestOrleansCluster();
            await _testCluster.StartAsync();
        }

        [Test]
        public async Task SimpleSetAndGet()
        {
            var nicholasCage = _testCluster.GetGrain<IActorGrain>("nickolasCage");
            await nicholasCage.SetName("Nicholas Cage");

            var title = await nicholasCage.GetName();
            title.ShouldBe("Nicholas Cage");
        }

        [OneTimeTearDown]
        public async Task TearDownAsync()
        {
            await _testCluster.ShutdownAsync();
        }
    }
}