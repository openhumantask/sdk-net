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
/// Represents the default implementation of the <see cref="IDeadlineDefinitionBuilder"/> interface.
/// </summary>
public class DeadlineDefinitionBuilder
    : IDeadlineDefinitionBuilder, ITypeDeadlineDefinitionBuilder
{

    /// <summary>
    /// Gets the <see cref="DeadlineDefinition"/> to configure
    /// </summary>
    protected DeadlineDefinition Definition { get; } = new();

    /// <inheritdoc/>
    public virtual ITypeDeadlineDefinitionBuilder WithName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        this.Definition.Name = name.Slugify("-").ToLowerInvariant();
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypeDeadlineDefinitionBuilder ElapsesAfter(TimeSpan duration)
    {
        this.Definition.ElapsesAt = null;
        this.Definition.ElapsesAfter = duration;
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypeDeadlineDefinitionBuilder ElapsesAt(DateTimeOffset dateTime)
    {
        if(dateTime < DateTimeOffset.UtcNow) throw new ArgumentOutOfRangeException(nameof(dateTime));
        this.Definition.ElapsesAt = dateTime;
        this.Definition.ElapsesAfter = null;
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypeDeadlineDefinitionBuilder Escalates(Action<IEscalationDefinitionBuilder> setup)
    {
        if (setup == null) throw new ArgumentNullException(nameof(setup));
        var builder = new EscalationDefinitionBuilder();
        setup(builder);
        if (this.Definition.Escalations == null) this.Definition.Escalations = new List<EscalationDefinition>();
        this.Definition.Escalations.Add(builder.Build());
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypeDeadlineDefinitionBuilder OfType(HumanTaskDeadlineType type)
    {
        this.Definition.Type = type;
        return this;
    }

    /// <inheritdoc/>
    public virtual DeadlineDefinition Build() => this.Definition;

}
