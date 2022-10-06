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
    /// Defines the fundamentals of a service used to build a typed <see cref="CompletionBehaviorDefinition"/>
    /// </summary>
    public interface ITypedCompletionBehaviorDefinitionBuilder
    {

        /// <summary>
        /// Configures the name of the <see cref="CompletionBehaviorDefinition"/> to build.
        /// </summary>
        /// <param name="name">The name of the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <returns>The configured <see cref="ITypedCompletionBehaviorDefinitionBuilder"/>.</returns>
        ITypedCompletionBehaviorDefinitionBuilder WithName(string name);

        /// <summary>
        /// Configures the output data set by the <see cref="CompletionBehaviorDefinition"/> when its condition matches.
        /// </summary>
        /// <param name="output">The output data to set when the <see cref="CompletionBehaviorDefinition"/> applies.</param>
        /// <returns>The configured <see cref="ITypedCompletionBehaviorDefinitionBuilder"/>.</returns>
        ITypedCompletionBehaviorDefinitionBuilder SetOutput(object? output);

        /// <summary>
        /// Configures the runtime expression to used to determine whether or not the <see cref="CompletionBehaviorDefinition"/> to build applies
        /// </summary>
        /// <param name="condition">The runtime expression used to determine whether or not the <see cref="CompletionBehaviorDefinition"/> to build applies</param>
        /// <returns>The configured <see cref="ITypedCompletionBehaviorDefinitionBuilder"/>.</returns>
        ITypedCompletionBehaviorDefinitionBuilder When(string? condition);

        /// <summary>
        /// Builds the configured <see cref="CompletionBehaviorDefinition"/>
        /// </summary>
        /// <returns>A new <see cref="CompletionBehaviorDefinition"/></returns>
        CompletionBehaviorDefinition Build();

    }

}
