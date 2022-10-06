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
    /// Represents the definition of an escalation that occurs if the human task has not reached a given status before a specific date and time, or before a given amount of time.
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#escalation-definitions"/></remarks>
    [DataContract]
    public class EscalationDefinition
    {

        /// <summary>
        /// Gets/sets the name of the <see cref="EscalationDefinition"/>.
        /// <para/>Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "name", IsRequired = true, Order = 1)]
        [JsonPropertyName("name")]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// Gets/sets a runtime expression that determines whether or not the deadline applies.
        /// </summary>
        [DataMember(Name = "condition", Order = 2)]
        [JsonPropertyName("condition")]
        public virtual string? Condition { get; set; }

        /// <summary>
        /// Gets/sets an object used to configured the escalation action to perform
        /// </summary>
        [Required]
        [DataMember(Name = "action", IsRequired = true, Order = 3)]
        [JsonPropertyName("action")]
        public virtual EscalationActionDefinition Action { get; set; } = null!;

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Name;
        }

    }

}
