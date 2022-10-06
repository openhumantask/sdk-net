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
    /// Defines extensions for <see cref="IHumanTaskDefinitionBuilder"/>s
    /// </summary>
    public static class IHumanTaskDefinitionBuilderExtensions
    {

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="CompletionBehaviorDefinition"/> of type <see cref="CompletionBehaviorType.Automatic"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHumanTaskDefinitionBuilder"/> to configure.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        public static IHumanTaskDefinitionBuilder UseAutomaticCompletionBehavior(this IHumanTaskDefinitionBuilder builder, Action<ITypedCompletionBehaviorDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            return builder.UseCompletionBehavior(behavior =>
            {
                var typedBehavior = behavior.OfType(CompletionBehaviorType.Automatic);
                setup(typedBehavior);
            });
        }

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="CompletionBehaviorDefinition"/> of type <see cref="CompletionBehaviorType.Automatic"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHumanTaskDefinitionBuilder"/> to configure.</param>
        /// <param name="name">The name of the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        public static IHumanTaskDefinitionBuilder UseAutomaticCompletionBehavior(this IHumanTaskDefinitionBuilder builder, string name, Action<ITypedCompletionBehaviorDefinitionBuilder> setup)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            return builder.UseAutomaticCompletionBehavior(behavior => 
            {
                behavior.WithName(name);
                setup(behavior);
            });
        }

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="CompletionBehaviorDefinition"/> of type <see cref="CompletionBehaviorType.Automatic"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHumanTaskDefinitionBuilder"/> to configure.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        public static IHumanTaskDefinitionBuilder UseManualCompletionBehavior(this IHumanTaskDefinitionBuilder builder, Action<ITypedCompletionBehaviorDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            return builder.UseCompletionBehavior(behavior =>
            {
                var typedBehavior = behavior.OfType(CompletionBehaviorType.Manual);
                setup(typedBehavior);
            });
        }

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="CompletionBehaviorDefinition"/> of type <see cref="CompletionBehaviorType.Automatic"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHumanTaskDefinitionBuilder"/> to configure.</param>
        /// <param name="name">The name of the <see cref="CompletionBehaviorDefinition"/> to build</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        public static IHumanTaskDefinitionBuilder UseManualCompletionBehavior(this IHumanTaskDefinitionBuilder builder, string name, Action<ITypedCompletionBehaviorDefinitionBuilder> setup)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            return builder.UseManualCompletionBehavior(behavior =>
            {
                behavior.WithName(name);
                setup(behavior);
            });
        }

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="DeadlineDefinition"/> of type <see cref="HumanTaskDeadlineType.Start"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHumanTaskDefinitionBuilder"/> to configure.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="DeadlineDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        public static IHumanTaskDefinitionBuilder UseStartDeadline(this IHumanTaskDefinitionBuilder builder, Action<ITypeDeadlineDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            return builder.UseDeadline(behavior =>
            {
                var typedDeadline = behavior.OfType(HumanTaskDeadlineType.Start);
                setup(typedDeadline);
            });
        }

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="DeadlineDefinition"/> of type <see cref="HumanTaskDeadlineType.Start"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHumanTaskDefinitionBuilder"/> to configure.</param>
        /// <param name="name">The name of the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        public static IHumanTaskDefinitionBuilder UseStartDeadline(this IHumanTaskDefinitionBuilder builder, string name, Action<ITypeDeadlineDefinitionBuilder> setup)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            return builder.UseStartDeadline(behavior =>
            {
                behavior.WithName(name);
                setup(behavior);
            });
        }

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="DeadlineDefinition"/> of type <see cref="HumanTaskDeadlineType.Completion"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHumanTaskDefinitionBuilder"/> to configure.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="DeadlineDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        public static IHumanTaskDefinitionBuilder UseCompletionDeadline(this IHumanTaskDefinitionBuilder builder, Action<ITypeDeadlineDefinitionBuilder> setup)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            return builder.UseDeadline(behavior =>
            {
                var typedDeadline = behavior.OfType(HumanTaskDeadlineType.Completion);
                setup(typedDeadline);
            });
        }

        /// <summary>
        /// Configures the <see cref="HumanTaskDefinition"/> to build to use the specified <see cref="DeadlineDefinition"/> of type <see cref="HumanTaskDeadlineType.Completion"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHumanTaskDefinitionBuilder"/> to configure.</param>
        /// <param name="name">The name of the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="CompletionBehaviorDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IHumanTaskDefinitionBuilder"/>.</returns>
        public static IHumanTaskDefinitionBuilder UseCompletionDeadline(this IHumanTaskDefinitionBuilder builder, string name, Action<ITypeDeadlineDefinitionBuilder> setup)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            return builder.UseCompletionDeadline(behavior =>
            {
                behavior.WithName(name);
                setup(behavior);
            });
        }

    }

}
