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
using System.Text.RegularExpressions;

namespace OpenHumanTask.Sdk.Services.FluentBuilders;

/// <summary>
/// Defines the fundamentals of a service used to build <see cref="UsersReferenceDefinition"/>s.
/// </summary>
public interface IUsersReferenceDefinitionBuilder
{

    /// <summary>
    /// Configures the <see cref="UsersReferenceDefinition"/> to build to filter users to reference based on their <see cref="Claim"/>s.
    /// </summary>
    /// <param name="type">The type of the <see cref="Claim"/> users to filter must own. Allows for <see cref="Regex"/>es.</param>
    /// <param name="value">The optional value of the specified <see cref="Claim"/> users to filter must own. Allows for <see cref="Regex"/>es.</param>
    /// <returns>A new <see cref="IClaimBasedUserReferenceDefinitionBuilder"/></returns>
    IClaimBasedUserReferenceDefinitionBuilder WithClaim(string type, string? value = null);

    /// <summary>
    /// Configures the <see cref="UsersReferenceDefinition"/> to build to filter users to reference based on their <see cref="Claim"/>s.
    /// </summary>
    /// <param name="value">The value of a <see cref="Claim"/> users to filter must own. Allows for <see cref="Regex"/>es.</param>
    /// <returns>A new <see cref="IClaimBasedUserReferenceDefinitionBuilder"/></returns>
    IClaimBasedUserReferenceDefinitionBuilder WithClaimValue(string value);

    /// <summary>
    /// Configures the <see cref="UsersReferenceDefinition"/> to build to filter users to reference based on the logical people group they belong to.
    /// </summary>
    /// <param name="group">The value of a <see cref="Claim"/> users to filter must own. Allows for <see cref="Regex"/>es.</param>
    void InGroup(string group);

    /// <summary>
    /// Configures the <see cref="UsersReferenceDefinition"/> to build to filter users to reference based on the <see cref="GenericHumanRole"/> they belong to.
    /// </summary>
    /// <param name="role">The <see cref="GenericHumanRole"/> users to filter must belong to.</param>
    void InRole(GenericHumanRole role);

}
