using Microsoft.Extensions.DependencyInjection;
using Neuroglia.Serialization;
using OpenHumanTask.Sdk.Services.IO;

namespace OpenHumanTask.Sdk.UnitTests.Cases.Services.IO
{

    public class HumanTaskDefinitionReaderTests
    {

        public HumanTaskDefinitionReaderTests()
        {
            var services = new ServiceCollection();
            services.AddOpenHumanTask();
            var provider = services.BuildServiceProvider();
            this.Reader = provider.GetRequiredService<IHumanTaskDefinitionReader>();
            this.JsonSerializer = provider.GetRequiredService<IJsonSerializer>();
            this.YamlSerializer = provider.GetRequiredService<IYamlSerializer>();
        }

        protected IHumanTaskDefinitionReader Reader { get; }

        protected ISerializer JsonSerializer { get; }

        protected ISerializer YamlSerializer { get; }

        [Fact]
        public async Task Read_Valid_Json_Definition_ShouldWork()
        {
            //arrange
            var toSerialize = HumanTaskDefinitionFactory.Create();
            using var stream = new MemoryStream();
            await this.JsonSerializer.SerializeAsync(toSerialize, stream);
            await stream.FlushAsync();
            stream.Position = 0;

            //var json = new StreamReader(stream).ReadToEnd();

            //act
            var deserialized = await this.Reader.ReadAsync(stream);

            //assert
            deserialized.Should().NotBeNull();
            deserialized.Should().BeEquivalentTo(toSerialize);
        }

        [Fact]
        public async Task Read_Valid_Yaml_Definition_ShouldWork()
        {
            //arrange
            var toSerialize = HumanTaskDefinitionFactory.Create();
            using var stream = new MemoryStream();
            await this.YamlSerializer.SerializeAsync(toSerialize, stream);
            await stream.FlushAsync();
            stream.Position = 0;

            var yaml = new StreamReader(stream).ReadToEnd();
            stream.Position = 0;

            //act
            var deserialized = await this.Reader.ReadAsync(stream);

            //assert
            deserialized.Should().NotBeNull();
            deserialized.Should().BeEquivalentTo(toSerialize);
        }

    }

}
