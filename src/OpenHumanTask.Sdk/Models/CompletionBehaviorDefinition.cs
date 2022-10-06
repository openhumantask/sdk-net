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
    /// Represents a task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#completion-behavior-definitions">completion behavior definition.</see>
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#completion-behavior-definitions"/></remarks>
    [DataContract]
    public class CompletionBehaviorDefinition
    {

        /// <summary>
        /// Gets/sets the name of the <see cref="CompletionBehaviorDefinition"/>.
        /// <para/>Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.*
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "name", IsRequired = true, Order = 1)]
        [JsonPropertyName("name")]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// Gets/sets the <see cref="CompletionBehaviorDefinition"/>'s type
        /// </summary>
        [Required, DefaultValue(CompletionBehaviorType.Automatic)]
        [DataMember(Name = "type", IsRequired = true, Order = 2)]
        [JsonPropertyName("type")]
        public virtual CompletionBehaviorType Type { get; set; } = CompletionBehaviorType.Automatic;

        /// <summary>
        /// Gets/sets a runtime expression that determines whether or not the completion behavior applies. If not set, the <see cref="CompletionBehaviorDefinition"/> is the task's default.
        /// </summary>
        [DataMember(Name = "condition", Order = 3)]
        [JsonPropertyName("condition")]
        public virtual string? Condition { get; set; }

        /// <summary>
        /// Gets a boolean indicating whether or not the <see cref="CompletionBehaviorDefinition"/> is the task's default
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual bool IsDefault => string.IsNullOrWhiteSpace(this.Condition);

        /// <summary>
        /// Gets/sets the data to use as the task's output.
        /// <para/>If a string, is a runtime expression used to build the task's output data based on contextual data.
        /// <para/>If an object, represents the task's output data. Runtime expressions can be used in any and all properties, at whichever depth.
        /// <para/>If not set, no output data is specified.
        /// </summary>
        [DataMember(Name = "output", Order = 4)]
        [JsonPropertyName("output")]
        public virtual object? Output { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Name;
        }

    }

}
