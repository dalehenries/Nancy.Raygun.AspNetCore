using Xunit;

namespace Nancy.Raygun.AspNetCore.Tests
{
    public class BasicTests
    {
        [Fact]
        public void Settings_can_read_key_from_appsettings_json_file()
        {
            // Given
            var apiKey = "YOUR_APP_API_KEY";

            // When
            var settings = RaygunSettings.Settings;

            // Then
            Assert.NotNull(settings);
            Assert.Equal(apiKey, settings.ApiKey);
        }
    }
}
