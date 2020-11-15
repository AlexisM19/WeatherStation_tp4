using OpenWeatherAPI;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        // useless?
        OpenWeatherProcessor _sut = OpenWeatherProcessor.Instance;

        [Fact]
        public async Task GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            // ARRANGE
            ApiHelper.InitializeClient();

            // ACTION
            _sut.ApiKey = null;

            // ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetOneCallAsync());
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            // ARRANGE
            ApiHelper.InitializeClient();


            // ACTION
            _sut.ApiKey = null;


            // ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetCurrentWeatherAsync());


        }

        [Fact]
        public async Task GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            // ARRANGE
            ApiHelper.ApiClient = null;

            // ACTION
            _sut.ApiKey = "OWApiKey";

            // ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetOneCallAsync());

        }

        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            // ARRANGE
            ApiHelper.ApiClient = null;

            // ACTION
            _sut.ApiKey = "OWApiKey";

            // ASSERT
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetCurrentWeatherAsync());

        }
    }
}
