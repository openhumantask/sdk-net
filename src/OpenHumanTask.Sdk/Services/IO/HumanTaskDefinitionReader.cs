// Copyright © 2022-Present The Open Human Task Specification Authors. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Extensions.Options;
using Neuroglia;

namespace OpenHumanTask.Sdk.Services.IO
{

    /// <summary>
    /// Represents the default implementation of the <see cref="IHumanTaskDefinitionReader"/> interface
    /// </summary>
    public class HumanTaskDefinitionReader
        : IHumanTaskDefinitionReader
    {

        /// <summary>
        /// Initializes a new <see cref="HumanTaskDefinitionReader"/>
        /// </summary>
        /// <param name="logger">The service used to perform logging</param>
        /// <param name="jsonSerializer">The service used to serialize and deserialize JSON</param>
        /// <param name="yamlSerializer">The service used to serialize and deserialize YAML</param>
        public HumanTaskDefinitionReader(ILogger<HumanTaskDefinitionReader> logger, IJsonSerializer jsonSerializer, IYamlSerializer yamlSerializer)
        {
            this.Logger = logger;
            this.JsonSerializer = jsonSerializer;
            this.YamlSerializer = yamlSerializer;
        }

        /// <summary>
        /// Gets the service used to perform logging
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// Gets the service used to serialize and deserialize JSON
        /// </summary>
        protected IJsonSerializer JsonSerializer { get; }

        /// <summary>
        /// Gets the service used to serialize and deserialize YAML
        /// </summary>
        protected IYamlSerializer YamlSerializer { get; }

        /// <inheritdoc/>
        public virtual async Task<HumanTaskDefinition> ReadAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if(stream == null) throw new ArgumentNullException(nameof(stream));
            Neuroglia.Serialization.ISerializer serializer;
            var offset = stream.Position;
            using var reader = new StreamReader(stream);
            var input = reader.ReadToEnd();
            stream.Position = offset;
            if (input.IsJson())
                serializer = this.JsonSerializer;
            else
                serializer = this.YamlSerializer;
            var definition = await serializer.DeserializeAsync<HumanTaskDefinition>(stream, cancellationToken);
            return definition;
        }

        /// <summary>
        /// Creates a new default instance of the <see cref="IHumanTaskDefinitionReader"/> interface
        /// </summary>
        /// <returns>A new <see cref="IHumanTaskDefinitionReader"/></returns>
        public static IHumanTaskDefinitionReader Create()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddOpenHumanTask();
            return services.BuildServiceProvider().GetRequiredService<IHumanTaskDefinitionReader>();
        }

    }

}
