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

namespace OpenHumanTask.Sdk.Models;

/// <summary>
/// Represents a task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#deadline-definitions">deadline definition.</see>
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#deadline-definitions"/></remarks>
[DataContract]
public record DeadlineDefinition
{

    /// <summary>
    /// Gets/sets the name of the <see cref="DeadlineDefinition"/>.
    /// <para/>Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.
    /// </summary>
    [Required, MinLength(3)]
    [DataMember(Name = "name", IsRequired = true, Order = 1), JsonPropertyOrder(1), JsonPropertyName("name"), YamlMember(Order = 1, Alias = "name")]
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Gets/sets the <see cref="DeadlineDefinition"/>'s type.
    /// </summary>
    [Required]
    [DataMember(Name = "type", IsRequired = true, Order = 2), JsonPropertyOrder(2), JsonPropertyName("type"), YamlMember(Order = 2, Alias = "type")]
    public virtual HumanTaskDeadlineType Type { get; set; }

    /// <summary>
    /// Gets/sets the date and time at which the <see cref="DeadlineDefinition"/> elapses and potentially triggers escalations. Required if <see cref="ElapsesAfter"/> has not been set, otherwise ignored.
    /// </summary>
    [DataMember(Name = "elapsesAt", Order = 3), JsonPropertyOrder(3), JsonPropertyName("elapsesAt"), YamlMember(Order = 3, Alias = "elapsesAt")]
    public virtual DateTimeOffset? ElapsesAt { get; set; }

    /// <summary>
    /// Gets/sets the duration after which the <see cref="DeadlineDefinition"/> elapses and potentially triggers escalations. Required if <see cref="ElapsesAt"/> has not been set, otherwise ignored.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Iso8601TimeSpanConverter)), JsonConverter(typeof(System.Text.Json.Serialization.Converters.Iso8601NullableTimeSpanConverter))]
    [DataMember(Name = "elapsesAfter", Order = 4), JsonPropertyOrder(4), JsonPropertyName("elapsesAfter"), YamlMember(Order = 4, Alias = "elapsesAfter")]
    public virtual TimeSpan? ElapsesAfter { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the <see cref="EscalationDefinition"/>s defined by the <see cref="DeadlineDefinition"/>.
    /// </summary>
    [Required, MinLength(1)]
    [DataMember(Name = "escalations", IsRequired = true, Order = 5), JsonPropertyOrder(5), JsonPropertyName("escalations"), YamlMember(Order = 5, Alias = "escalations")]
    public virtual List<EscalationDefinition> Escalations { get; set; } = new List<EscalationDefinition>();

}
