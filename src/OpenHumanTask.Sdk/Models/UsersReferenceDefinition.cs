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
    /// Represents an object used to reference multiple users
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#users-reference-definitions"/></remarks>
    [DataContract]
    public class UsersReferenceDefinition
    {

        /// <summary>
        /// Gets/sets the claims to filter by the users to reference. Required if '<see cref="InGroup"/>' and '<see cref="InGenericRole"/>' have not been set, otherwise ignored.
        /// </summary>
        [DataMember(Name = "withClaims", Order = 1)]
        [JsonPropertyName("withClaims")]
        public virtual List<ClaimFilterDefinition>? WithClaims { get; set; }

        /// <summary>
        /// Gets/sets the claims to filter by the users to reference. Required if '<see cref="WithClaims"/>' and '<see cref="InGenericRole"/>' have not been set, otherwise ignored.
        /// </summary>
        [DataMember(Name = "inGroup", Order = 2)]
        [JsonPropertyName("inGroup")]
        public virtual string? InGroup { get; set; }

        /// <summary>
        /// Gets/sets the claims to filter by the users to reference. Required if '<see cref="WithClaims"/>' and '<see cref="InGroup"/>' have not been set, otherwise ignored.
        /// </summary>
        [DataMember(Name = "inGenericRole", Order = 3)]
        [JsonPropertyName("inGenericRole")]
        public virtual GenericHumanRole? InGenericRole { get; set; }

    }

}
