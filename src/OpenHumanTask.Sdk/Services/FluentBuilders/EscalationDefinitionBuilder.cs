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
/// Represents the default implementation of the <see cref="IEscalationDefinitionBuilder"/> interface.
/// </summary>
public class EscalationDefinitionBuilder
    : IEscalationDefinitionBuilder
{

    /// <summary>
    /// Gets the <see cref="EscalationDefinition"/> to configure.
    /// </summary>
    protected EscalationDefinition Definition { get; } = new();

    /// <inheritdoc/>
    public virtual IEscalationDefinitionBuilder WithName(string name)
    {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        this.Definition.Name = name.Slugify("-").ToLowerInvariant();
        return this;
    }

    /// <inheritdoc/>
    public virtual IEscalationDefinitionBuilder When(string? condition)
    {
        if (!string.IsNullOrWhiteSpace(condition) && !condition.IsRuntimeExpression()) 
            throw new ArgumentNullException(nameof(condition), $"The specified value '{condition}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format");
        this.Definition.Condition = condition;
        return this;
    }

    /// <inheritdoc/>
    public virtual void Notify(Action<INotificationDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new NotificationDefinitionBuilder();
        setup(builder);
        if (this.Definition.Action == null) this.Definition.Action = new();
        this.Definition.Action.Notification = builder.Build();
    }

    /// <inheritdoc/>
    public virtual void Reassign(Action<IReassignmentDefinitionBuilder>? setup = null)
    {
        var builder = new ReassignmentDefinitionBuilder();
        setup?.Invoke(builder);
        if (this.Definition.Action == null) this.Definition.Action = new();
        this.Definition.Action.Reassignment = builder.Build();
    }

    /// <inheritdoc/>
    public virtual void StartSubtask(Action<ISubtaskDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new SubtaskDefinitionBuilder();
        setup(builder);
        if (this.Definition.Action == null) this.Definition.Action = new();
        this.Definition.Action.Subtask = builder.Build();
    }

    /// <inheritdoc/>
    public virtual EscalationDefinition Build() => this.Definition;

}
