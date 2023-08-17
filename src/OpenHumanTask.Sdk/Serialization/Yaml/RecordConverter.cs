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

using YamlDotNet.Core;

namespace OpenHumanTask.Sdk.Serialization.Yaml;

/// <summary>
/// Represents an <see cref="IYamlTypeConverter"/> used to convert enumerations to/from strings.
/// </summary>
public class RecordConverter
    : INodeDeserializer
{

    /// <summary>
    /// Initializes a new <see cref="RecordConverter"/>
    /// </summary>
    /// <param name="inner">The inner <see cref="INodeDeserializer"/></param>
    public RecordConverter(INodeDeserializer inner)
    {
        this.Inner = inner;
    }

    /// <summary>
    /// Gets the inner <see cref="INodeDeserializer"/>
    /// </summary>
    protected INodeDeserializer Inner { get; }

    /// <inheritdoc/>
    public virtual bool Deserialize(IParser reader, Type expectedType, Func<IParser, Type, object?> nestedObjectDeserializer, out object? value)
    {
        if (!expectedType.GetMethods().Any(m => m.Name == "<Clone>$")) return this.Inner.Deserialize(reader, expectedType, nestedObjectDeserializer, out value);
        if (!this.Inner.Deserialize(reader, typeof(Dictionary<string, object>), nestedObjectDeserializer, out value)) return false;
        value = System.Text.Json.JsonSerializer.Deserialize(System.Text.Json.JsonSerializer.Serialize(value), expectedType);
        return true;
    }

}