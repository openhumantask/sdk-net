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

namespace OpenHumanTask.Sdk.Services.FluentBuilders;

/// <summary>
/// Represents the default implementation of the <see cref="IPeopleReferenceDefinitionBuilder"/> interface
/// </summary>
public class PeopleReferenceDefinitionBuilder
    : IPeopleReferenceDefinitionBuilder, IUsersReferenceDefinitionBuilder, IClaimBasedUserReferenceDefinitionBuilder
{

    /// <summary>
    /// Gets the <see cref="PeopleReferenceDefinition"/> to configure
    /// </summary>
    protected PeopleReferenceDefinition Definition { get; } = new();

    /// <inheritdoc/>
    public virtual void User(string userIdentifier)
    {
        if (string.IsNullOrWhiteSpace(userIdentifier)) throw new ArgumentNullException(nameof(userIdentifier));
        this.Definition.User = userIdentifier;
    }

    /// <inheritdoc/>
    public virtual IUsersReferenceDefinitionBuilder Users() => this;

    /// <inheritdoc/>
    public virtual IClaimBasedUserReferenceDefinitionBuilder WithClaim(string type, string? value = null)
    {
        if (string.IsNullOrWhiteSpace(type)) throw new ArgumentNullException(nameof(type));
        if (this.Definition.Users == null) this.Definition.Users = new();
        if (this.Definition.Users.WithClaims == null) this.Definition.Users.WithClaims = new();
        this.Definition.Users.WithClaims.Add(new() { Type = type, Value = value });
        return this;
    }

    /// <inheritdoc/>
    public virtual IClaimBasedUserReferenceDefinitionBuilder WithClaimValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        if (this.Definition.Users == null) this.Definition.Users = new();
        if (this.Definition.Users.WithClaims == null) this.Definition.Users.WithClaims = new();
        this.Definition.Users.WithClaims.Add(new() { Value = value });
        return this;
    }

    /// <inheritdoc/>
    public virtual void InGroup(string group)
    {
        if (string.IsNullOrWhiteSpace(group)) throw new ArgumentNullException(nameof(group));
        if (this.Definition.Users == null) this.Definition.Users = new();
        this.Definition.Users.InGroup = group;
    }

    /// <inheritdoc/>
    public virtual void InRole(GenericHumanRole role)
    {
        if (this.Definition.Users == null) this.Definition.Users = new();
        this.Definition.Users.InGenericRole = role;
    }

    /// <inheritdoc/>
    public virtual PeopleReferenceDefinition Build() => this.Definition;

}
