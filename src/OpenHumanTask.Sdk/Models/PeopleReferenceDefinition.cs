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

namespace OpenHumanTask.Sdk.Models;

/// <summary>
/// Represents an object used to reference a user or a group of users based on given parameters.
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#people-reference-definitions"/></remarks>
[DataContract]
public record PeopleReferenceDefinition
{

    /// <summary>
    /// Gets/sets an identifier used to reference a single the user. Required if the '<see cref="Users"/>' property has not been set.
    /// </summary>
    [DataMember(Name = "user", Order = 1), JsonPropertyOrder(1), JsonPropertyName("user"), YamlMember(Order = 1, Alias = "user")]
    public virtual string? User { get; set; }

    /// <summary>
    /// Gets/sets an object used to reference multiple users. Required if the '<see cref="User"/>' property has not been set.
    /// </summary>
    [DataMember(Name = "users", Order = 2), JsonPropertyOrder(2), JsonPropertyName("users"), YamlMember(Order = 2, Alias = "users")]
    public virtual UsersReferenceDefinition? Users { get; set; }

}
