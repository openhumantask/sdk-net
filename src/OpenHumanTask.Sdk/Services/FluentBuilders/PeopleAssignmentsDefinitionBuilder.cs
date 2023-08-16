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
/// Represents the default implementation of the <see cref="IPeopleAssignmentsDefinitionBuilder"/> interface
/// </summary>
public class PeopleAssignmentsDefinitionBuilder
    : IPeopleAssignmentsDefinitionBuilder
{

    /// <summary>
    /// Gets the <see cref="PeopleAssignmentsDefinition"/> to configure
    /// </summary>
    protected PeopleAssignmentsDefinition Definition { get; } = new();

    /// <inheritdoc/>
    public virtual IPeopleAssignmentsDefinitionBuilder ToPotentialInitiators(Action<IPeopleReferenceDefinitionBuilder> setup)
    {
        if(setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new PeopleReferenceDefinitionBuilder();
        setup(builder);
        if (this.Definition.PotentialInitiators == null) this.Definition.PotentialInitiators = new List<PeopleReferenceDefinition>();
        this.Definition.PotentialInitiators.Add(builder.Build());
        return this;
    }

    /// <inheritdoc/>
    public virtual IPeopleAssignmentsDefinitionBuilder ToPotentialOwners(Action<IPeopleReferenceDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new PeopleReferenceDefinitionBuilder();
        setup(builder);
        if (this.Definition.PotentialOwners == null) this.Definition.PotentialOwners = new List<PeopleReferenceDefinition>();
        this.Definition.PotentialOwners.Add(builder.Build());
        return this;
    }

    /// <inheritdoc/>
    public virtual IPeopleAssignmentsDefinitionBuilder ToExcludedOwners(Action<IPeopleReferenceDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new PeopleReferenceDefinitionBuilder();
        setup(builder);
        if (this.Definition.ExcludedOwners == null) this.Definition.ExcludedOwners = new List<PeopleReferenceDefinition>();
        this.Definition.ExcludedOwners.Add(builder.Build());
        return this;
    }

    /// <inheritdoc/>
    public virtual IPeopleAssignmentsDefinitionBuilder ToStakeholders(Action<IPeopleReferenceDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new PeopleReferenceDefinitionBuilder();
        setup(builder);
        if (this.Definition.Stakeholders == null) this.Definition.Stakeholders = new List<PeopleReferenceDefinition>();
        this.Definition.Stakeholders.Add(builder.Build());
        return this;
    }

    /// <inheritdoc/>
    public virtual IPeopleAssignmentsDefinitionBuilder ToBusinessAdministrators(Action<IPeopleReferenceDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new PeopleReferenceDefinitionBuilder();
        setup(builder);
        if (this.Definition.BusinessAdministrators == null) this.Definition.BusinessAdministrators = new List<PeopleReferenceDefinition>();
        this.Definition.BusinessAdministrators.Add(builder.Build());
        return this;
    }

    /// <inheritdoc/>
    public virtual IPeopleAssignmentsDefinitionBuilder ToNotificationRecipients(Action<IPeopleReferenceDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new PeopleReferenceDefinitionBuilder();
        setup(builder);
        if (this.Definition.NotificationRecipients == null) this.Definition.NotificationRecipients = new List<PeopleReferenceDefinition>();
        this.Definition.NotificationRecipients.Add(builder.Build());
        return this;
    }

    /// <inheritdoc/>
    public virtual IPeopleAssignmentsDefinitionBuilder ToGroup(string groupName, Action<IPeopleReferenceDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new PeopleReferenceDefinitionBuilder();
        setup(builder);
        if (this.Definition.Groups == null) this.Definition.Groups = new List<LogicalPeopleGroupDefinition>();
        var group = this.Definition.Groups.FirstOrDefault(g => g.Name.Equals(groupName, StringComparison.InvariantCultureIgnoreCase));
        if (group == null)
        {
            group = new() { Name = groupName.Slugify("-").ToLowerInvariant() };
            this.Definition.Groups.Add(group);
        }
        group.Members ??= new List<PeopleReferenceDefinition>();
        group.Members.Add(builder.Build());
        return this;
    }

    /// <inheritdoc/>
    public virtual PeopleAssignmentsDefinition Build() => this.Definition;

}
