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

using System.Text.Json.Serialization.Converters;

namespace OpenHumanTask.Sdk.Models;

/// <summary>
/// Represents the <see href="https://github.com/openhumantask/specification/blob/main/specification.md#view-definitions">definition of a view</see>
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#view-definitions"/></remarks>
[DataContract]
public record ViewDefinition
{

    /// <summary>
    /// Gets/sets the view type
    /// </summary>
    [DataMember(Name = "type", Order = 1), JsonPropertyOrder(1), JsonPropertyName("type"), YamlMember(Order = 1, Alias = "type")]
    public virtual string Type { get; set; } = null!;

    /// <summary>
    /// Gets/sets the view's rendering mode
    /// </summary>
    [DataMember(Name = "renderingMode", Order = 2), JsonPropertyOrder(2), JsonPropertyName("renderingMode"), YamlMember(Order = 2, Alias = "renderingMode")]
    public virtual ViewRenderingMode RenderingMode { get; set; } = ViewRenderingMode.Process;

    /// <summary>
    /// Gets/sets the view template. If a string, the raw template contents. If an object, the inline template. Can be a (or contain) runtime expression(s).
    /// </summary>
    [JsonConverter(typeof(JsonElementConverter))]
    [DataMember(Name = "template", Order = 3), JsonPropertyOrder(3), JsonPropertyName("template"), YamlMember(Order = 3, Alias = "template")]
    public virtual object Template { get; set; } = null!;

}
