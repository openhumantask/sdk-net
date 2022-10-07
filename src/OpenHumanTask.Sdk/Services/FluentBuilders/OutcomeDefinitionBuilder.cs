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
    /// Represents the default implementation of the <see cref="IOutcomeDefinitionBuilder"/> interface
    /// </summary>
    public class OutcomeDefinitionBuilder
        : IOutcomeDefinitionBuilder
    {

        /// <summary>
        /// Gets the <see cref="OutcomeDefinition"/> to configure.
        /// </summary>
        protected OutcomeDefinition Definition { get; } = new();

        /// <inheritdoc/>
        public virtual IOutcomeDefinitionBuilder WithName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            this.Definition.Name = name.Slugify("-").ToLowerInvariant();
            return this;
        }

        /// <inheritdoc/>
        public virtual IOutcomeDefinitionBuilder Outputs(string language, string? value)
        {
            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));
            if (language.IsValidLanguageCode()) throw new ArgumentException($"The specified value '{language}' is not a valid two-letter ISO 639-1 language code.", nameof(language));
            IDictionary<string, string?> values;
            if (this.Definition.Value == null) values = new Dictionary<string, string?>();
            else if (this.Definition.Value is string) values = new Dictionary<string, string?>();
            else values = this.Definition.Value.ToDictionary<string?>();
            values[language] = value;
            this.Definition.Value = values;
            return this;
        }

        /// <inheritdoc/>
        public virtual IOutcomeDefinitionBuilder Outputs(string? value)
        {
            this.Definition.Value = value;
            return this;
        }

        /// <inheritdoc/>
        public virtual IOutcomeDefinitionBuilder When(string? condition)
        {
            if (!string.IsNullOrWhiteSpace(condition) && !condition.IsRuntimeExpression()) 
                throw new ArgumentException(nameof(condition), new FormatException($"The specified value '{condition}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format"));
            this.Definition.Condition = condition;
            return this;
        }

        /// <inheritdoc/>
        public virtual OutcomeDefinition Build() => this.Definition;

    }

}
