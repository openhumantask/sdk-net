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
    /// Represents a logical group of people which can be referenced in the task's scope.
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#logical-people-group-definitions"/></remarks>
    [DataContract]
    public class LogicalPeopleGroupDefinition
    {

        /// <summary>
        /// Gets/sets the name used to referenced the group in the task's scope. Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.
        /// </summary>
        [Required, MinLength(1)]
        [DataMember(Name = "name", IsRequired = true, Order = 1)]
        [JsonPropertyName("name")]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// Gets/sets an <see cref="List{T}"/> containing the defined group's members
        /// </summary>
        [Required, MinLength(1)]
        [DataMember(Name = "members", IsRequired = true, Order = 2)]
        [JsonPropertyName("members")]
        public virtual List<PeopleReferenceDefinition> Members { get; set; } = new List<PeopleReferenceDefinition>();

    }

}
