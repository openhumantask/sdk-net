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
/// Represents the default implementation of the <see cref="ISubtaskDefinitionBuilder"/> interface.
/// </summary>
public class SubtaskDefinitionBuilder
    : ISubtaskDefinitionBuilder
{

    /// <summary>
    /// Gets the <see cref="SubtaskDefinition"/> to configure.
    /// </summary>
    protected SubtaskDefinition Definition { get; } = new();

    /// <inheritdoc/>
    public virtual ISubtaskDefinitionBuilder WithName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        this.Definition.Name = name.Slugify("-").ToLowerInvariant();
        return this;
    }

    /// <inheritdoc/>
    public virtual ISubtaskDefinitionBuilder WithDefinition(string definitionId)
    {
        if (string.IsNullOrWhiteSpace(definitionId)) throw new ArgumentNullException(nameof(definitionId));
        if (!definitionId.IsTaskDefinitionReference()) throw new ArgumentException($"Invalid argument '{nameof(definitionId)}'. View inner exception for further details.", new FormatException($"The specified value '{definitionId}' is not a valid human task definition reference."));
        this.Definition.Task = definitionId!;
        return this;
    }

    /// <inheritdoc/>
    public virtual ISubtaskDefinitionBuilder WithDefinition(string name, string @namespace, string version)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));
        if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
        this.Definition.Task = new() 
        { 
            Name = name.Slugify("-").ToLowerInvariant(),
            Namespace = @namespace.Slugify("-").ToLowerInvariant(),
            Version = version.ToLowerInvariant(),
        };
        return this;
    }

    /// <inheritdoc/>
    public virtual ISubtaskDefinitionBuilder WithInput(object? input)
    {
        if (input != null && input is string expression && !expression.IsRuntimeExpression()) throw new ArgumentException($"Invalid argument '{nameof(input)}'. View inner exception for further details.", $"The specified value '{expression}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format");
        this.Definition.Input = input;
        return this;
    }

    /// <inheritdoc/>
    public virtual SubtaskDefinition Build() => this.Definition;

}
