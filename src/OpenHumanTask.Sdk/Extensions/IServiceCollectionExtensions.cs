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

using FluentValidation;
using OpenHumanTask.Sdk.Services.IO;
using YamlDotNet.Serialization.NodeDeserializers;

namespace OpenHumanTask.Sdk;

/// <summary>
/// Defines extensions for <see cref="IServiceCollection"/>s
/// </summary>
public static class IServiceCollectionExtensions
{

    /// <summary>
    /// Adds and configures Open Human Task services (<see cref="Neuroglia.Serialization.ISerializer"/>s, <see cref="IHumanTaskDefinitionReader"/>, ...)
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to configure</param>
    /// <returns>The configured <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddOpenHumanTask(this IServiceCollection services)
    {
        services.AddJsonSerializer(options =>
        {
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });
        services.AddYamlDotNetSerializer(
           serializer => serializer
               .IncludeNonPublicProperties()
               .WithEmissionPhaseObjectGraphVisitor(args => new ChainedObjectGraphVisitor(args.InnerVisitor))
               .WithTypeConverter(new Serialization.Yaml.Iso8601TimeSpanConverter())
               .WithTypeConverter(new Serialization.Yaml.Iso8601DateTimeOffsetConverter())
               .WithTypeConverter(new Serialization.Yaml.StringEnumConverter()),
           deserializer => deserializer
               .WithNodeDeserializer(
                   inner => new Iso8601TimeSpanConverter(inner),
                   syntax => syntax.InsteadOf<ScalarNodeDeserializer>())
               .WithTypeConverter(new Serialization.Yaml.Iso8601DateTimeOffsetConverter())
               .WithTypeConverter(new Serialization.Yaml.StringEnumConverter()));
        services.AddHttpClient();
        services.AddSingleton<IHumanTaskDefinitionReader, HumanTaskDefinitionReader>();
        services.AddValidatorsFromAssemblyContaining<IHumanTaskDefinitionReader>(ServiceLifetime.Singleton);
        return services;
    }

}
