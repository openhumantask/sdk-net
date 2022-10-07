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

using System.Linq.Expressions;
using System.Xml.Linq;
using YamlDotNet.Core.Tokens;

namespace OpenHumanTask.Sdk.Services.FluentBuilders
{

    /// <summary>
    /// Represents the default implementation of the <see cref="IHumanTaskDefinitionBuilder"/> interface
    /// </summary>
    public class HumanTaskDefinitionBuilder
        : IHumanTaskDefinitionBuilder
    {

        /// <summary>
        /// Gets the <see cref="HumanTaskDefinition"/> to configure
        /// </summary>
        protected HumanTaskDefinition Definition { get; } = new();

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            this.Definition.Name = name.Slugify("-").ToLowerInvariant();
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithNamespace(string @namespace)
        {
            if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));
            var parts = @namespace.Split('.', StringSplitOptions.RemoveEmptyEntries);
            this.Definition.Namespace = string.Join('.', @namespace.Split('.', StringSplitOptions.RemoveEmptyEntries).Select(p => p.Slugify("-").ToLowerInvariant()));
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithVersion(string version)
        {
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
            if (SemanticVersion.TryParse(version, out _)) throw new ArgumentException($"The specified value '{version}' is not a valid semantic version.", nameof(version));
            this.Definition.Version = version;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder UseSpecVersion(string version)
        {
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
            if (SemanticVersion.TryParse(version, out _)) throw new ArgumentException($"The specified value '{version}' is not a valid semantic version.", nameof(version));
            this.Definition.SpecVersion = version;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithKey(string? key)
        {
            if (!string.IsNullOrWhiteSpace(key) && !key.IsRuntimeExpression()) throw new ArgumentNullException(nameof(key), new FormatException($"The specified value '{key}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format"));
            this.Definition.Key = key;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithInputData(JSchema schema, object? state)
        {
            if (state != null && state is string expression && !expression.IsRuntimeExpression())
                throw new ArgumentNullException(nameof(state), new FormatException($"The specified value '{expression}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format"));
            this.Definition.InputData = new() { Schema = schema, State = state };
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithInputData(JSchema schema)
        {
            if (this.Definition.InputData == null) this.Definition.InputData = new();
            this.Definition.InputData.Schema = schema;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithInputData(object? state)
        {
            if (state != null && state is string expression && !expression.IsRuntimeExpression())
                throw new ArgumentNullException(nameof(state), new FormatException($"The specified value '{expression}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format"));
            if (this.Definition.InputData == null) this.Definition.InputData = new();
            this.Definition.InputData.State = state;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithOutputData(JSchema schema, object? state)
        {
            if (state != null && state is string expression && !expression.IsRuntimeExpression())
                throw new ArgumentNullException(nameof(state), new FormatException($"The specified value '{expression}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format"));
            this.Definition.OutputData = new() { Schema = schema, State = state };
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithOutputDataSchema(JSchema schema)
        {
            if (this.Definition.OutputData == null) this.Definition.OutputData = new();
            this.Definition.OutputData.Schema = schema;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithOutputDataState(object? state)
        {
            if (state != null && state is string expression && !expression.IsRuntimeExpression())
                throw new ArgumentNullException(nameof(state), new FormatException($"The specified value '{expression}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format"));
            if (this.Definition.OutputData == null) this.Definition.OutputData = new();
            this.Definition.OutputData.State = state;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder UseExpressionLanguage(string language)
        {
            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));
            this.Definition.ExpressionLanguage = language;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder UseRoutingMode(HumanTaskRoutingMode routingMode)
        {
            this.Definition.RoutingMode = routingMode;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithTitle(string title)
        {
            this.Definition.Title = title;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithTitle(string language, string title)
        {
            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));
            if (!language.IsValidLanguageCode()) throw new ArgumentException($"The specified value '{language}' is not a valid two-letter ISO 639-1 language code.", nameof(language));
            IDictionary<string, string> values;
            if (this.Definition.Title == null) values = new Dictionary<string, string>();
            else if (this.Definition.Title is string) values = new Dictionary<string, string>();
            else values = this.Definition.Title.ToDictionary<string>();
            values[language] = title;
            this.Definition.Title = values;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithSubject(string subject)
        {
            this.Definition.Subject = subject;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithSubject(string language, string subject)
        {
            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));
            if (!language.IsValidLanguageCode()) throw new ArgumentException($"The specified value '{language}' is not a valid two-letter ISO 639-1 language code.", nameof(language));
            IDictionary<string, string> values;
            if (this.Definition.Subject == null) values = new Dictionary<string, string>();
            else if (this.Definition.Subject is string) values = new Dictionary<string, string>();
            else values = this.Definition.Subject.ToDictionary<string>();
            values[language] = subject;
            this.Definition.Subject = values;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithDescription(string description)
        {
            this.Definition.Description = description;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder WithDescription(string language, string description)
        {
            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));
            if (!language.IsValidLanguageCode()) throw new ArgumentException($"The specified value '{language}' is not a valid two-letter ISO 639-1 language code.", nameof(language));
            IDictionary<string, string> values;
            if (this.Definition.Description == null) values = new Dictionary<string, string>();
            else if (this.Definition.Description is string) values = new Dictionary<string, string>();
            else values = this.Definition.Description.ToDictionary<string>();
            values[language] = description;
            this.Definition.Description = values;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder Assign(Action<IPeopleAssignmentsDefinitionBuilder> setup)
        {
            if(setup == null) throw new ArgumentNullException(nameof(setup));
            var builder = new PeopleAssignmentsDefinitionBuilder();
            setup(builder);
            this.Definition.PeopleAssignments = builder.Build();
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder UseForm(Action<IFormDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            var builder = new FormDefinitionBuilder();
            setup(builder);
            this.Definition.Form = builder.Build();
            return this;
        }

        /// <inheritdoc/>
        public IHumanTaskDefinitionBuilder UseDeadline(Action<IDeadlineDefinitionBuilder> setup)
        {
            if(setup == null) throw new ArgumentNullException(nameof(setup));
            var builder = new DeadlineDefinitionBuilder();
            setup(builder);
            if (this.Definition.Deadlines == null) this.Definition.Deadlines = new List<DeadlineDefinition>();
            this.Definition.Deadlines.Add(builder.Build());
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder UseCompletionBehavior(Action<ICompletionBehaviorDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            var builder = new CompletionBehaviorDefinitionBuilder();
            setup(builder);
            if (this.Definition.CompletionBehaviors == null) this.Definition.CompletionBehaviors = new List<CompletionBehaviorDefinition>();
            this.Definition.CompletionBehaviors.Add(builder.Build());
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder AddSubtask(Action<ISubtaskDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            if (this.Definition.Subtasks == null) this.Definition.Subtasks = new();
            var builder = new SubtaskDefinitionBuilder();
            setup(builder);
            this.Definition.Subtasks.Add(builder.Build());
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder AddOutcome(Action<IOutcomeDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            if (this.Definition.Outcomes == null) this.Definition.Outcomes = new();
            var builder = new OutcomeDefinitionBuilder();
            setup(builder);
            this.Definition.Outcomes.Add(builder.Build());
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder AnnotateWith(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (this.Definition.Annotations == null) this.Definition.Annotations = new();
            this.Definition.Annotations[key] = value;
            return this;
        }

        /// <inheritdoc/>
        public virtual IHumanTaskDefinitionBuilder UseMetadata(object? metadata)
        {
            this.Definition.Metadata = metadata;
            return this;
        }

        /// <inheritdoc/>
        public virtual HumanTaskDefinition Build()
        {
            if (string.IsNullOrWhiteSpace(this.Definition.Id))
                this.Definition.Id = HumanTaskDefinition.BuildId(this.Definition.Name, this.Definition.Namespace, this.Definition.Version);
            return this.Definition;
        }


    }

}
