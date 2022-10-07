﻿// Copyright © 2022-Present The Open Human Task Specification Authors. All rights reserved.
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
    /// Defines the fundamentals of a service used to build <see cref="ViewDefinition"/>s
    /// </summary>
    public interface IViewDefinitionBuilder
    {

        /// <summary>
        /// Configures the type of the <see cref="ViewDefinition"/> to build.
        /// </summary>
        /// <param name="type">The type of the <see cref="ViewDefinition"/> to build.</param>
        /// <returns>The configured <see cref="IEscalationDefinitionBuilder"/>.</returns>
        ITypedViewDefinitionBuilder OfType(string type);
     
    }

}