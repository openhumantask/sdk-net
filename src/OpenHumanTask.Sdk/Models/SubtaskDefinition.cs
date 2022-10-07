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

using System.Text.Json.Serialization.Converters;

namespace OpenHumanTask.Sdk.Models
{
    /// <summary>
    /// Represents the <see href="https://github.com/openhumantask/specification/blob/main/specification.md#subtask-definitions">definition of a subtask.</see>
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#subtask-definitions"/></remarks>
    [DataContract]
    public class SubtaskDefinition
    {

        /// <summary>
        /// Gets/sets the subtask's name. Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "name", IsRequired = true, Order = 1)]
        [JsonPropertyName("name")]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// Gets/sets a reference to the <see cref="HumanTaskDefinition"/> to instanciate.
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "task", IsRequired = true, Order = 2)]
        [JsonPropertyName("task")]
        public virtual TaskDefinitionReference Task { get; set; } = null!;

        /// <summary>
        /// Gets/sets the data to pass as the subtask's input.
        /// <para/>If a string , is a runtime expression used to build the subtask's input data based on the human task's data.
        /// <para/>If an object, represents the input data of the subtask to create.runtime expressions can be used in any and all properties, at whichever depth.
        /// <para/>If not set, no input data is supplied to the subtask.
        /// </summary>
        [DataMember(Name = "input", Order = 3)]
        [JsonPropertyName("input"), JsonConverter(typeof(JsonElementConverter))]
        public virtual object? Input { get; set; }

    }

}
