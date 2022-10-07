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
    /// Represents the default implementation of the <see cref="IFormDefinitionBuilder"/> interface.
    /// </summary>
    public class FormDefinitionBuilder
        : IFormDefinitionBuilder
    {

        /// <summary>
        /// Gets the <see cref="FormDefinition"/> to configure.
        /// </summary>
        protected FormDefinition Definition { get; } = new();

        /// <inheritdoc/>
        public virtual IFormDefinitionBuilder WithData(JSchema schema, object? state)
        {
            if (state != null && state is string expression && !expression.IsRuntimeExpression())
                throw new ArgumentNullException(nameof(state), new FormatException($"The specified value '{expression}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format"));
            this.Definition.Data = new() { Schema = schema, State = state };
            return this;
        }

        /// <inheritdoc/>
        public virtual IFormDefinitionBuilder WithData(JSchema schema)
        {
            if (this.Definition.Data == null) this.Definition.Data = new();
            this.Definition.Data.Schema = schema;
            return this;
        }

        /// <inheritdoc/>
        public virtual IFormDefinitionBuilder WithData(object? state)
        {
            if (state != null && state is string expression && !expression.IsRuntimeExpression())
                throw new ArgumentNullException(nameof(state), new FormatException($"The specified value '{expression}' is not a valid runtime expression, or does not use the mandatory '${{ expression }}' format"));
            if (this.Definition.Data == null) this.Definition.Data = new();
            this.Definition.Data.State = state;
            return this;
        }

        /// <inheritdoc/>
        public virtual IFormDefinitionBuilder DisplayUsing(Action<IViewDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));

            return this;
        }

        /// <inheritdoc/>
        public virtual FormDefinition Build() => this.Definition;

    }

}
