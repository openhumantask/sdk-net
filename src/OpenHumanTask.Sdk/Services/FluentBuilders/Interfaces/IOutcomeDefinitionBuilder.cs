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
    /// Defines the fundamentals of a service used to build <see cref="OutcomeDefinition"/>s.
    /// </summary>
    public interface IOutcomeDefinitionBuilder
    {

        /// <summary>
        /// Configures the name of the <see cref="OutcomeDefinition"/> to build.
        /// </summary>
        /// <param name="name">The name of the <see cref="OutcomeDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IOutcomeDefinitionBuilder"/>.</returns>
        IOutcomeDefinitionBuilder WithName(string name);

        /// <summary>
        /// Configures the runtime expression to used to determine whether or not the <see cref="OutcomeDefinition"/> to build applies
        /// </summary>
        /// <param name="condition">The runtime expression used to determine whether or not the <see cref="OutcomeDefinition"/> to build applies</param>
        /// <returns>The configured <see cref="IOutcomeDefinitionBuilder"/>.</returns>
        IOutcomeDefinitionBuilder When(string? condition);

        /// <summary>
        /// Configures the <see cref="OutcomeDefinition"/> to build to output the specified value when it applies.
        /// </summary>
        /// <param name="language">The two-letter ISO 639-1 code of the language the specified value is expressed in.</param>
        /// <param name="value">The value to output.</param>
        /// <returns>The configured <see cref="IOutcomeDefinitionBuilder"/>.</returns>
        IOutcomeDefinitionBuilder Outputs(string language, string? value);

        /// <summary>
        /// Configures the <see cref="OutcomeDefinition"/> to build to output the specified value when it applies.
        /// </summary>
        /// <param name="value">The culture-invariant value to output.</param>
        /// <returns>The configured <see cref="IOutcomeDefinitionBuilder"/>.</returns>
        IOutcomeDefinitionBuilder Outputs(string? value);

        /// <summary>
        /// Builds the configured <see cref="OutcomeDefinition"/>
        /// </summary>
        /// <returns>A new <see cref="OutcomeDefinition"/></returns>
        OutcomeDefinition Build();

    }

}
