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
/// Represents the default implementation of the <see cref="ICompletionBehaviorDefinitionBuilder"/> interface
/// </summary>
public class CompletionBehaviorDefinitionBuilder
    : ICompletionBehaviorDefinitionBuilder, ITypedCompletionBehaviorDefinitionBuilder
{

    /// <summary>
    /// Gets the <see cref="CompletionBehaviorDefinition"/> to configure
    /// </summary>
    protected CompletionBehaviorDefinition Definition { get; } = new();

    /// <inheritdoc/>
    public virtual ITypedCompletionBehaviorDefinitionBuilder OfType(CompletionBehaviorType type)
    {
        this.Definition.Type = type;
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypedCompletionBehaviorDefinitionBuilder WithName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        this.Definition.Name = name.Slugify("-").ToLowerInvariant();
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypedCompletionBehaviorDefinitionBuilder SetOutput(object? output)
    {
        if (output != null && output is string expression && !expression.IsRuntimeExpression()) 
            throw new ArgumentNullException(nameof(output), $"The specified value '{expression}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format");
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypedCompletionBehaviorDefinitionBuilder When(string? condition)
    {
        if (!string.IsNullOrWhiteSpace(condition) && !condition.IsRuntimeExpression()) 
            throw new ArgumentNullException(nameof(condition), $"The specified value '{condition}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format");
        this.Definition.Condition = condition;
        return this;
    }

    /// <inheritdoc/>
    public virtual CompletionBehaviorDefinition Build() => this.Definition;

}
