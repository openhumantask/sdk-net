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

namespace OpenHumanTask.Sdk.Services.FluentBuilders
{

    /// <summary>
    /// Defines the fundamentals of a service used to configure a task's <see cref="PeopleAssignmentsDefinition"/>
    /// </summary>
    public interface IPeopleAssignmentsDefinitionBuilder
    {

        /// <summary>
        /// Configures the potential initiators of the task to build the <see cref="PeopleAssignmentsDefinition"/> for.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the potential initiators to add.</param>
        /// <returns>The configured <see cref="IPeopleAssignmentsDefinitionBuilder"/>.</returns>
        IPeopleAssignmentsDefinitionBuilder ToPotentialInitiators(Action<IPeopleReferenceDefinitionBuilder> setup);

        /// <summary>
        /// Configures the potential owners of the task to build the <see cref="PeopleAssignmentsDefinition"/> for.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the potential owners to add</param>.
        /// <returns>The configured <see cref="IPeopleAssignmentsDefinitionBuilder"/>.</returns>
        IPeopleAssignmentsDefinitionBuilder ToPotentialOwners(Action<IPeopleReferenceDefinitionBuilder> setup);

        /// <summary>
        /// Configures the excluded owners of the task to build the <see cref="PeopleAssignmentsDefinition"/> for.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the excluded owners to add.</param>
        /// <returns>The configured <see cref="IPeopleAssignmentsDefinitionBuilder"/>.</returns>
        IPeopleAssignmentsDefinitionBuilder ToExcludedOwners(Action<IPeopleReferenceDefinitionBuilder> setup);

        /// <summary>
        /// Configures the stakeholders of the task to build the <see cref="PeopleAssignmentsDefinition"/> for.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the stakeholders to add.</param>
        /// <returns>The configured <see cref="IPeopleAssignmentsDefinitionBuilder"/>.</returns>
        IPeopleAssignmentsDefinitionBuilder ToStakeholders(Action<IPeopleReferenceDefinitionBuilder> setup);

        /// <summary>
        /// Configures the business administrators of the task to build the <see cref="PeopleAssignmentsDefinition"/> for.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the business administrators to add.</param>
        /// <returns>The configured <see cref="IPeopleAssignmentsDefinitionBuilder"/>.</returns>
        IPeopleAssignmentsDefinitionBuilder ToBusinessAdministrators(Action<IPeopleReferenceDefinitionBuilder> setup);

        /// <summary>
        /// Configures the notification recipients of the task to build the <see cref="PeopleAssignmentsDefinition"/> for.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the notification recipients to add.</param>
        /// <returns>The configured <see cref="IPeopleAssignmentsDefinitionBuilder"/>.</returns>
        IPeopleAssignmentsDefinitionBuilder ToNotificationRecipients(Action<IPeopleReferenceDefinitionBuilder> setup);

        /// <summary>
        /// Configures the members of the specified group
        /// </summary>
        /// <param name="group">The name of the group to assign members to.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the notification recipients to add.</param>
        /// <returns>The configured <see cref="IPeopleAssignmentsDefinitionBuilder"/>.</returns>
        IPeopleAssignmentsDefinitionBuilder ToGroup(string group, Action<IPeopleReferenceDefinitionBuilder> setup);

        /// <summary>
        /// Builds the configured <see cref="PeopleAssignmentsDefinition"/>
        /// </summary>
        /// <returns>A new <see cref="PeopleAssignmentsDefinition"/></returns>
        PeopleAssignmentsDefinition Build();

    }

}
