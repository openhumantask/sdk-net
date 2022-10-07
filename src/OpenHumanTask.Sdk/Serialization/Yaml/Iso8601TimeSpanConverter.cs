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

using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

namespace OpenHumanTask.Sdk.Serialization.Yaml
{

    /// <summary>
    /// Represents an <see cref="IYamlTypeConverter"/> used to convert <see cref="TimeSpan"/>s to/from an ISO 8601 string
    /// </summary>
    public class Iso8601TimeSpanConverter
        : IYamlTypeConverter
    {

        /// <inheritdoc/>
        public virtual bool Accepts(Type type) => type == typeof(TimeSpan) || type == typeof(TimeSpan?);

        /// <inheritdoc/>
        public virtual object? ReadYaml(IParser parser, Type type)
        {
            var scalar = parser.Consume<Scalar>().Value;
            var timeSpan = string.IsNullOrWhiteSpace(scalar) ? default : Iso8601TimeSpan.Parse(scalar);
            if (type.IsNullable() && timeSpan == default) return null;
            return timeSpan;
        }

        /// <inheritdoc/>
        public virtual void WriteYaml(IEmitter emitter, object? value, Type type)
        {
            var timespan = (TimeSpan?)value;
            var formatted = timespan == null ? null : Iso8601TimeSpan.Format(timespan.Value);
            emitter.Emit(new Scalar(AnchorName.Empty, TagName.Empty, formatted!, ScalarStyle.Any, true, false));
        }

    }

}
