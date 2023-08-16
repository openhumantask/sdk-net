﻿// Copyright © 2022-Present The Open Human Task Specification Authors. All rights reserved.
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
/// Defines the fundamentals of a service used to build <see cref="FormDefinition"/>s.
/// </summary>
public interface IFormDefinitionBuilder
{

    /// <summary>
    /// Configures the <see cref="FormDefinition"/> to build to use the specified data <see cref="JSchema"/> and initial state.
    /// </summary>
    /// <param name="schema">The <see cref="JSchema"/> of the <see cref="FormDefinition"/>'s data.</param>
    /// <param name="state">The initial state of the <see cref="HumanTaskDefinition"/>'s data. Used to filter and customize data based on supplied input.</param>
    /// <returns>The configured <see cref="IFormDefinitionBuilder"/>.</returns>
    IFormDefinitionBuilder WithData(JSchema schema, object? state);

    /// <summary>
    /// Configures the <see cref="FormDefinition"/> to build to use the specified data <see cref="JSchema"/>.
    /// </summary>
    /// <param name="schema">The <see cref="JSchema"/> of the <see cref="FormDefinition"/>'s data.</param>
    /// <returns>The configured <see cref="IFormDefinitionBuilder"/>.</returns>
    IFormDefinitionBuilder WithData(JSchema schema);

    /// <summary>
    /// Configures the <see cref="FormDefinition"/> to build to use the specified data initial state.
    /// </summary>
    /// <param name="state">The initial state of the <see cref="FormDefinition"/>'s data. Used to filter and customize data based on supplied input.</param>
    /// <returns>The configured <see cref="IFormDefinitionBuilder"/>.</returns>
    IFormDefinitionBuilder WithData(object? state);

    /// <summary>
    /// Configures the <see cref="FormDefinition"/> to build to be displayed using the specified view.
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to build the <see cref="FormDefinition"/>'s <see cref="ViewDefinition"/>.</param>
    /// <returns>The configured <see cref="IFormDefinitionBuilder"/>.</returns>
    IFormDefinitionBuilder DisplayUsing(Action<IViewDefinitionBuilder> setup);

    /// <summary>
    /// Builds the configured <see cref="FormDefinition"/>
    /// </summary>
    /// <returns>A new <see cref="FormDefinition"/></returns>
    FormDefinition Build();

}
