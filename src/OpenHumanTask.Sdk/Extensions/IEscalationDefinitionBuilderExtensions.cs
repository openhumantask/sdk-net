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

using OpenHumanTask.Sdk.Services.FluentBuilders;

namespace OpenHumanTask.Sdk
{
    /// <summary>
    /// Defines extensions for <see cref="IEscalationDefinitionBuilder"/>s
    /// </summary>
    public static class IEscalationDefinitionBuilderExtensions
    {

        /// <summary>
        /// Configures the <see cref="EscalationDefinition"/> to build to start a subtask when applying.
        /// </summary>
        /// <param name="builder">The <see cref="IEscalationDefinitionBuilder"/> to configure.</param>
        /// <param name="name">The name of the <see cref="SubtaskDefinition"/> to create.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to configure the <see cref="SubtaskDefinition"/> to create.</param>
        public static void StartSubtask(this IEscalationDefinitionBuilder builder, string name, Action<ISubtaskDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            builder.StartSubtask(subtask => setup(subtask.WithName(name)));
        }

    }

}
