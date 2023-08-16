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
/// Defines the fundamentals of a service used to build typed <see cref="ViewDefinition"/>s
/// </summary>
public interface ITypedViewDefinitionBuilder
{

    /// <summary>
    /// Configures the type of the <see cref="ViewDefinition"/> to build.
    /// </summary>
    /// <param name="renderingMode">The <see cref="ViewRenderingMode"/> of the <see cref="ViewDefinition"/> to build.</param>
    /// <returns>The configured <see cref="IEscalationDefinitionBuilder"/>.</returns>
    ITypedViewDefinitionBuilder UseRenderingMode(ViewRenderingMode renderingMode);

    /// <summary>
    /// Configures the template of the <see cref="ViewDefinition"/> to build.
    /// </summary>
    /// <param name="template">The template of the <see cref="ViewDefinition"/> to build. If a string, the raw template contents. If an object, the inline template. Can be a (or contain) runtime expression(s).</param>
    /// <returns>The configured <see cref="IEscalationDefinitionBuilder"/>.</returns>
    ITypedViewDefinitionBuilder WithTemplate(object template);

    /// <summary>
    /// Builds the configured <see cref="ViewDefinition"/>
    /// </summary>
    /// <returns>A new <see cref="ViewDefinition"/></returns>
    ViewDefinition Build();

}
