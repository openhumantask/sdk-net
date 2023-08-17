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
/// Represents the default implementation of the <see cref="IViewDefinitionBuilder"/> interface.
/// </summary>
public class ViewDefinitionBuilder
    : IViewDefinitionBuilder, ITypedViewDefinitionBuilder
{

    /// <summary>
    /// Gets the <see cref="ViewDefinition"/> to configure.
    /// </summary>
    protected ViewDefinition Definition { get; } = new();

    /// <inheritdoc/>
    public virtual ITypedViewDefinitionBuilder OfType(string type)
    {
        if (string.IsNullOrWhiteSpace(type)) throw new ArgumentNullException(nameof(type));
        this.Definition.Type = type;
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypedViewDefinitionBuilder UseRenderingMode(ViewRenderingMode renderingMode)
    {
        this.Definition.RenderingMode = renderingMode;
        return this;
    }

    /// <inheritdoc/>
    public virtual ITypedViewDefinitionBuilder WithTemplate(object template)
    {
        this.Definition.Template = template ?? throw new ArgumentNullException(nameof(template));
        return this;
    }

    /// <inheritdoc/>
    public virtual ViewDefinition Build() => this.Definition;

}
