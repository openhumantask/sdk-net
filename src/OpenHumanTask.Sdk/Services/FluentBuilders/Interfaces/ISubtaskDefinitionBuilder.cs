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
    /// Defines the fundamentals of a service used to build <see cref="SubtaskDefinition"/>s
    /// </summary>
    public interface ISubtaskDefinitionBuilder
    {

        /// <summary>
        /// Configures the name of the <see cref="SubtaskDefinition"/> to build.
        /// </summary>
        /// <param name="name">The name of the human task definition. Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.</param>
        /// <returns>The configured <see cref="ISubtaskDefinitionBuilder"/>.</returns>
        ISubtaskDefinitionBuilder WithName(string name);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> created by the of the <see cref="SubtaskDefinition"/> to build.
        /// </summary>
        /// <param name="definitionId">The globally unique identifier of the human task definition to create.</param>
        /// <returns>The configured <see cref="ISubtaskDefinitionBuilder"/>.</returns>
        ISubtaskDefinitionBuilder WithDefinition(string definitionId);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> created by the of the <see cref="SubtaskDefinition"/> to build.
        /// </summary>
        /// <param name="name">The name of the human task definition to create.</param>
        /// <param name="namespace">The namespace of the human task definition to create.</param>
        /// <param name="version">The semantic version of the human task definition to create.</param>
        /// <returns>The configured <see cref="ISubtaskDefinitionBuilder"/>.</returns>
        ISubtaskDefinitionBuilder WithDefinition(string name, string @namespace, string version);

        /// <summary>
        /// Configures the input to instanciate the <see cref="SubtaskDefinition"/> to build.
        /// </summary>
        /// <param name="input">The data to pass as the subtask's input. 
        /// <para/>If a string , is a runtime expression used to build the subtask's input data based on the human task's data. 
        /// <para/>If an object, represents the input data of the subtask to create.runtime expressions can be used in any and all properties, at whichever depth. 
        /// <para/>If not set, no input data is supplied to the subtask..</param>
        /// <returns>The configured <see cref="ISubtaskDefinitionBuilder"/>.</returns>
        ISubtaskDefinitionBuilder WithInput(object? input);

        /// <summary>
        /// Builds the configured <see cref="SubtaskDefinition"/>
        /// </summary>
        /// <returns>A new <see cref="SubtaskDefinition"/></returns>
        SubtaskDefinition Build();

    }

}
