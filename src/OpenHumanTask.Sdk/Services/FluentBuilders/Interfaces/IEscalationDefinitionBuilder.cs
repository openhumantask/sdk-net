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
/// Defines the fundamentals of a service used to build <see cref="EscalationDefinition"/>s.
/// </summary>
public interface IEscalationDefinitionBuilder
{

    /// <summary>
    /// Configures the name of the <see cref="EscalationDefinition"/> to build.
    /// </summary>
    /// <param name="name">The name of the human task definition. Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.</param>
    /// <returns>The configured <see cref="IEscalationDefinitionBuilder"/>.</returns>
    IEscalationDefinitionBuilder WithName(string name);

    /// <summary>
    /// Configures the runtime expression to used to determine whether or not the <see cref="EscalationDefinition"/> to build applies
    /// </summary>
    /// <param name="condition">The runtime expression used to determine whether or not the <see cref="EscalationDefinition"/> to build applies</param>
    /// <returns>The configured <see cref="ITypedCompletionBehaviorDefinitionBuilder"/>.</returns>
    IEscalationDefinitionBuilder When(string? condition);

    /// <summary>
    /// Configures the <see cref="EscalationDefinition"/> to build to create a notification when applying.
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to configure the <see cref="NotificationDefinition"/> to create.</param>
    void Notify(Action<INotificationDefinitionBuilder> setup);

    /// <summary>
    /// Configures the <see cref="EscalationDefinition"/> to build to reassign the task when applying.
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to configure the <see cref="ReassignmentDefinition"/> to create.</param>
    void Reassign(Action<IReassignmentDefinitionBuilder>? setup = null);

    /// <summary>
    /// Configures the <see cref="EscalationDefinition"/> to build to start a subtask when applying.
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to configure the <see cref="SubtaskDefinition"/> to create.</param>
    void StartSubtask(Action<ISubtaskDefinitionBuilder> setup);

    /// <summary>
    /// Builds the configured <see cref="EscalationDefinition"/>
    /// </summary>
    /// <returns>A new <see cref="EscalationDefinition"/></returns>
    EscalationDefinition Build();

}
