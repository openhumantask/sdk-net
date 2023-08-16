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

using System.Text.Json.Serialization.Converters;

namespace OpenHumanTask.Sdk.Models;

/// <summary>
/// Represents the definition of a notification, which is use to communicate the status of the task to users.
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#notification-definitions"/></remarks>
[DataContract]
public record NotificationDefinition
{

    /// <summary>
    /// Gets/sets the name of the <see cref="NotificationDefinition"/>.
    /// <para/>Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.
    /// </summary>
    [Required, MinLength(3)]
    [DataMember(Name = "name", IsRequired = true, Order = 1), JsonPropertyOrder(1), JsonPropertyName("name"), YamlMember(Order = 1, Alias = "name")]
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the the notification's views.
    /// </summary>
    [Required, MinLength(1)]
    [DataMember(Name = "views", IsRequired = true, Order = 2), JsonPropertyOrder(2), JsonPropertyName("views"), YamlMember(Order = 2, Alias = "views")]
    public virtual List<ViewDefinition> Views { get; set; } = new List<ViewDefinition>();

    /// <summary>
    /// Gets the defined notification's input. If a string, is a runtime expression used to build the notification's input data based on the human task's data. If an object, represents the input data of the notification to produce.runtime expressions can be used in any and all properties, at whichever depth.
    /// </summary>
    [JsonConverter(typeof(JsonElementConverter))]
    [DataMember(Name = "input", Order = 3), JsonPropertyOrder(3), JsonPropertyName("input"), YamlMember(Order = 3, Alias = "input")]
    public virtual object? Input { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> that contains the notification's recipients. If set, overrides the <see cref="HumanTaskDefinition"/>'s <see cref="PeopleAssignmentsDefinition.NotificationRecipients"/> property
    /// </summary>
    [DataMember(Name = "recipients", Order = 4), JsonPropertyOrder(4), JsonPropertyName("recipients"), YamlMember(Order = 4, Alias = "recipients")]
    public virtual List<PeopleReferenceDefinition>? Recipients { get; set; }

}
