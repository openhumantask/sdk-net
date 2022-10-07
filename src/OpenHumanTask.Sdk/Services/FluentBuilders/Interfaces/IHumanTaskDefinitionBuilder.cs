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
    /// Defines the fundamentals of a service used to build <see cref="HumanTaskDefinition"/>s
    /// </summary>
    public interface IHumanTaskDefinitionBuilder
    {

        /// <summary>
        /// Configures the name of the <see cref="HumanTaskDefinition"/> to build.
        /// </summary>
        /// <param name="name">The name of the human task definition. Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithName(string name);

        /// <summary>
        /// Configures the namespace of the <see cref="HumanTaskDefinition"/> to build.
        /// </summary>
        /// <param name="namespace">The @namespace of the human task definition. Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' and '.' characters.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithNamespace(string @namespace);

        /// <summary>
        /// Configures the version of the <see cref="HumanTaskDefinition"/> to build.
        /// </summary>
        /// <param name="version">The semantic version of the human task definition.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithVersion(string version);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified OHT spec version.
        /// </summary>
        /// <param name="version">The OHT spec version to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder UseSpecVersion(string version);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified key.
        /// </summary>
        /// <param name="key">A runtime expression used to determine the keys of instances of the <see cref="HumanTaskDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithKey(string? key);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified input data <see cref="JSchema"/> and initial state.
        /// </summary>
        /// <param name="schema">The <see cref="JSchema"/> of the <see cref="HumanTaskDefinition"/>'s input data.</param>
        /// <param name="state">The initial state of the <see cref="HumanTaskDefinition"/>'s input data. Used to filter and customize data based on supplied input.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithInputData(JSchema schema, object? state);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified input data <see cref="JSchema"/>.
        /// </summary>
        /// <param name="schema">The <see cref="JSchema"/> of the <see cref="HumanTaskDefinition"/>'s input data.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithInputData(JSchema schema);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified input data initial state.
        /// </summary>
        /// <param name="state">The initial state of the <see cref="HumanTaskDefinition"/>'s input data. Used to filter and customize data based on supplied input.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithInputData(object? state);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified output data <see cref="JSchema"/> and initial state.
        /// </summary>
        /// <param name="schema">The <see cref="JSchema"/> of the <see cref="HumanTaskDefinition"/>'s output data.</param>
        /// <param name="state">The initial state of the <see cref="HumanTaskDefinition"/>'s output data. Used to filter and customize data based on supplied output.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithOutputData(JSchema schema, object? state);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified output data <see cref="JSchema"/>.
        /// </summary>
        /// <param name="schema">The <see cref="JSchema"/> of the <see cref="HumanTaskDefinition"/>'s output data.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithOutputDataSchema(JSchema schema);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified output data initial state.
        /// </summary>
        /// <param name="state">The initial state of the <see cref="HumanTaskDefinition"/>'s output data. Used to filter and customize data based on supplied output.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithOutputDataState(object? state);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified runtime expression language.
        /// </summary>
        /// <param name="language">The runtime expression language to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder UseExpressionLanguage(string language);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="HumanTaskRoutingMode"/>.
        /// </summary>
        /// <param name="routingMode">The <see cref="HumanTaskRoutingMode"/> to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder UseRoutingMode(HumanTaskRoutingMode routingMode);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified culture-invariant title.
        /// </summary>
        /// <param name="title">The culture-invariant title to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithTitle(string title);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified title in the specified language.
        /// </summary>
        /// <param name="language">The two letter ISO 639-1 name of the language the title to use is expressed in.</param>
        /// <param name="title">The title to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithTitle(string language, string title);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified culture-invariant subject.
        /// </summary>
        /// <param name="subject">The culture-invariant subject to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithSubject(string subject);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified subject in the specified language.
        /// </summary>
        /// <param name="language">The two letter ISO 639-1 name of the language the subject to use is expressed in.</param>
        /// <param name="subject">The subject to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithSubject(string language, string subject);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified culture-invariant description.
        /// </summary>
        /// <param name="description">The culture-invariant description to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithDescription(string description);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified description in the specified language.
        /// </summary>
        /// <param name="language">The two letter ISO 639-1 name of the language the description to use is expressed in.</param>
        /// <param name="description">The description to use.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder WithDescription(string language, string description);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="DeadlineDefinition"/>.
        /// </summary>
        /// <param name="setup">The <see cref="Action{T}"/> used to configure the <see cref="DeadlineDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder UseDeadline(Action<IDeadlineDefinitionBuilder> setup);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified completion behavior.
        /// </summary>
        /// <param name="setup">The <see cref="Action{T}"/> used to configure the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        IHumanTaskDefinitionBuilder UseCompletionBehavior(Action<ICompletionBehaviorDefinitionBuilder> setup);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to define the specified outcome.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to configure the <see cref="OutcomeDefinition"/> to add.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/></returns>
        IHumanTaskDefinitionBuilder AddOutcome(Action<IOutcomeDefinitionBuilder> setup);

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to define the specified subtask.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to configure the <see cref="SubtaskDefinition"/> to add.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/></returns>
        IHumanTaskDefinitionBuilder AddSubtask(Action<ISubtaskDefinitionBuilder> setup);

        /// <summary>
        /// Assigns the <see cref="HumanTaskDefinition"/> to build to the specified people.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to configure the people to assign the <see cref="HumanTaskDefinition"/> to build to.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/></returns>
        IHumanTaskDefinitionBuilder Assign(Action<IPeopleAssignmentsDefinitionBuilder> setup);

        /// <summary>
        /// Builds the configured <see cref="HumanTaskDefinition"/>
        /// </summary>
        /// <returns>A new <see cref="HumanTaskDefinition"/></returns>
        HumanTaskDefinition Build();

    }

}
