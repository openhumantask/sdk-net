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
    /// Represents the <see href="https://github.com/openhumantask/specification/blob/main/specification.md#form-definitions">definition of a human task form</see>
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#form-definitions"/></remarks>
    [DataContract]
    public class FormDefinition
    {

        /// <summary>
        /// Gets/sets the <see cref="DataModelDefinition"/> used to describe the form's data, if any
        /// </summary>
        [DataMember(Name = "data", Order = 1)]
        [JsonPropertyName("data")]
        public virtual DataModelDefinition? Data { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="ICollection{T}"/> containing the form's <see cref="ViewDefinition"/>s
        /// </summary>
        [DataMember(Name = "views", Order = 2)]
        [JsonPropertyName("views")]
        public virtual ICollection<ViewDefinition> Views { get; set; } = new List<ViewDefinition>();

    }

}
