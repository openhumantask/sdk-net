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
    /// Represents an object used to declare, configure and validate a data model
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#data-model-definitions"/></remarks>
    [DataContract]
    public class DataModelDefinition
    {

        /// <summary>
        /// Gets/sets the definedd model's <see cref="JSchema"/>, if any
        /// </summary>
        [DataMember(Name = "schema", Order = 1)]
        [JsonPropertyName("schema")]
        public virtual JSchema? Schema { get; set; }

        /// <summary>
        /// Gets/sets an object that defines the defined model's initial stater
        /// </summary>
        [DataMember(Name = "state", Order = 2)]
        [JsonPropertyName("state"), JsonConverter(typeof(JsonElementConverter))]
        public virtual object? State { get; set; }

    }

}
