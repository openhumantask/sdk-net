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
    /// Defines the fundamentals of a service used to build typed <see cref="DeadlineDefinition"/>s.
    /// </summary>
    public interface ITypeDeadlineDefinitionBuilder
    {

        /// <summary>
        /// Configures the name of the <see cref="DeadlineDefinition"/> to build.
        /// </summary>
        /// <param name="name">The name of the <see cref="DeadlineDefinition"/> to build.</param>
        /// <returns>The configured <see cref="ITypeDeadlineDefinitionBuilder"/></returns>
        ITypeDeadlineDefinitionBuilder WithName(string name);

        /// <summary>
        /// Configures the <see cref="DeadlineDefinition"/> to build to elapse at the specified date and time.
        /// </summary>
        /// <param name="dateTime">The date and time at which the <see cref="DeadlineDefinition"/> to build elapses.</param>
        /// <returns>The configured <see cref="ITypeDeadlineDefinitionBuilder"/></returns>
        ITypeDeadlineDefinitionBuilder ElapsesAt(DateTimeOffset dateTime);

        /// <summary>
        /// Configures the <see cref="DeadlineDefinition"/> to build to elapse after the specified duration.
        /// </summary>
        /// <param name="duration">The duration after which the <see cref="DeadlineDefinition"/> to build elapses.</param>
        /// <returns>The configured <see cref="ITypeDeadlineDefinitionBuilder"/></returns>
        ITypeDeadlineDefinitionBuilder ElapsesAfter(TimeSpan duration);

        /// <summary>
        /// Adds and configures a new <see cref="EscalationDefinition"/> to the <see cref="DeadlineDefinition"/> to build.
        /// </summary>
        /// <param name="setup">An <see cref="Action{T}"/> used to configure the <see cref="EscalationDefinition"/> to use.</param>
        /// <returns>The configured <see cref="ITypeDeadlineDefinitionBuilder"/></returns>
        ITypeDeadlineDefinitionBuilder Escalates(Action<IEscalationDefinitionBuilder> setup);

        /// <summary>
        /// Builds the configured <see cref="DeadlineDefinition"/>.
        /// </summary>
        /// <returns>A new <see cref="DeadlineDefinition"/>.</returns>
        DeadlineDefinition Build();

    }

}
