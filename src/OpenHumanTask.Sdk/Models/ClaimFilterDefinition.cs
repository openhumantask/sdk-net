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

using System.Security.Claims;

namespace OpenHumanTask.Sdk.Models
{
    /// <summary>
    /// Represents a <see cref="Claim"/>-based filter
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#claim-filter-definitions"/></remarks>
    [DataContract]
    public class ClaimFilterDefinition
    {

        /// <summary>
        /// Gets/sets the type of the <see cref="Claim"/> matching users must own. If used in conjunction with the '<see cref="Value"/>' property, filters users that have a <see cref="Claim"/> of the specified type, with the specified value.
        /// </summary>
        [DataMember(Name = "type", Order = 1)]
        [JsonPropertyName("type")]
        public virtual string? Type { get; set; }

        /// <summary>
        /// Gets/sets a claim value matching users must own. If the '<see cref="Type"/>' property has not been set, filters users that have a <see cref="Claim"/> of any type containing the specified value.
        /// </summary>
        [DataMember(Name = "value", Order = 2)]
        [JsonPropertyName("value")]
        public virtual string? Value { get; set; }

    }

}
