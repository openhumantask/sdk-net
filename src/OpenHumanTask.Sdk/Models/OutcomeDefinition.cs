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

namespace OpenHumanTask.Sdk.Models
{
    /// <summary>
    /// Represents the definition of a task's outcome.
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#outcome-definitions"/>.</remarks>
    [DataContract]
    public class OutcomeDefinition
    {

        /// <summary>
        /// Gets/sets the name of the <see cref="OutcomeDefinition"/>.
        /// <para/>Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.*
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "name", IsRequired = true, Order = 1)]
        [JsonPropertyName("name")]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// Gets/sets a runtime expression that determines whether or not the outcome applies. If not set, the <see cref="OutcomeDefinition"/> is the task's default.
        /// </summary>
        [DataMember(Name = "condition", Order = 2)]
        [JsonPropertyName("condition")]
        public virtual string? Condition { get; set; }

        /// <summary>
        /// Gets a boolean indicating whether or not the <see cref="OutcomeDefinition"/> is the task's default
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual bool IsDefault => string.IsNullOrWhiteSpace(this.Condition);

        /// <summary>
        /// Gets/sets he outcome's localized values. If a string, the culture-invariant outcome's value. If an object, the mappings of localized values to their two-letter ISO 639-1 language names.Must declare at least one language/value pair.
        /// </summary>
        [DataMember(Name = "value", Order = 4)]
        [JsonPropertyName("value")]
        public virtual object? Value { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Name;
        }

    }

}
