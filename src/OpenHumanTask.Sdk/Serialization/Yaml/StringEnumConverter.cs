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

using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

namespace OpenHumanTask.Sdk.Serialization.Yaml
{
    /// <summary>
    /// Represents an <see cref="IYamlTypeConverter"/> used to convert enumerations to/from strings.
    /// </summary>
    public class StringEnumConverter 
        : IYamlTypeConverter
    {

        /// <inheritdoc/>
        public bool Accepts(Type type) => type.IsEnum;

        /// <inheritdoc/>
        public object ReadYaml(IParser parser, Type type)
        {
            var parsedEnum = parser.Consume<Scalar>();
            var serializableValues = type.GetMembers()
                .Select(m => new KeyValuePair<string, MemberInfo>(m.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault()!, m))
                .Where(pa => !string.IsNullOrWhiteSpace(pa.Key)).ToDictionary(pa => pa.Key, pa => pa.Value);
            if (!serializableValues.ContainsKey(parsedEnum.Value))
                throw new YamlException(parsedEnum.Start, parsedEnum.End, $"Value '{parsedEnum.Value}' not found in enum '{type.Name}'");
            return Enum.Parse(type, serializableValues[parsedEnum.Value].Name);
        }

        /// <inheritdoc/>
        public void WriteYaml(IEmitter emitter, object? value, Type type)
        {
            var enumMember = type.GetMember(value?.ToString()!).FirstOrDefault();
            var yamlValue = enumMember?.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault() ?? value.ToString();
            emitter.Emit(new Scalar(yamlValue!));
        }
    }

}
