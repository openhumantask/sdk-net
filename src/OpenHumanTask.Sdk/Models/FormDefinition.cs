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

namespace OpenHumanTask.Sdk.Models;

/// <summary>
/// Represents the <see href="https://github.com/openhumantask/specification/blob/main/specification.md#form-definitions">definition of a human task form</see>
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#form-definitions"/></remarks>
[DataContract]
public record FormDefinition
{

    /// <summary>
    /// Gets/sets the <see cref="DataModelDefinition"/> used to describe the form's data, if any
    /// </summary>
    [DataMember(Name = "data", Order = 1), JsonPropertyOrder(1), JsonPropertyName("data"), YamlMember(Order = 1, Alias = "data")]
    public virtual DataModelDefinition? Data { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the form's <see cref="ViewDefinition"/>s
    /// </summary>
    [Required, MinLength(1)]
    [DataMember(Name = "views", Order = 2), JsonPropertyOrder(2), JsonPropertyName("views")]
    public virtual List<ViewDefinition> Views { get; set; } = new List<ViewDefinition>();

}
