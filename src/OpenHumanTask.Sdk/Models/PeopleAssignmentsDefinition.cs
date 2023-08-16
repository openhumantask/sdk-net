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
/// Represents the definition used to configure people assignments for instance of the human task definition.
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#people-assignments-definitions"/></remarks>
[DataContract]
public record PeopleAssignmentsDefinition
{

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#potential-initiators">potential initiators</see>
    /// </summary>
    [DataMember(Name = "potentialInitiators", Order = 1), JsonPropertyOrder(1), JsonPropertyName("potentialInitiators"), YamlMember(Order = 1, Alias = "potentialInitiators")]
    public virtual List<PeopleReferenceDefinition>? PotentialInitiators { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#potential-owners">potential owners</see>
    /// </summary>
    [DataMember(Name = "potentialOwners", Order = 2), JsonPropertyOrder(2), JsonPropertyName("potentialOwners"), YamlMember(Order = 2, Alias = "potentialOwners")]
    public virtual List<PeopleReferenceDefinition>? PotentialOwners { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#excluded-owners">excluded owners</see>
    /// </summary>
    [DataMember(Name = "excludedOwners", Order = 3), JsonPropertyOrder(3), JsonPropertyName("excludedOwners"), YamlMember(Order = 3, Alias = "excludedOwners")]
    public virtual List<PeopleReferenceDefinition>? ExcludedOwners { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#stakeholders">stakeholders</see>
    /// </summary>
    [DataMember(Name = "stakeholders", Order = 4), JsonPropertyOrder(4), JsonPropertyName("stakeholders"), YamlMember(Order = 4, Alias = "stakeholders")]
    public virtual List<PeopleReferenceDefinition>? Stakeholders { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#business-administrators">business administrators</see>
    /// </summary>
    [DataMember(Name = "businessAdministrators", Order = 5), JsonPropertyOrder(5), JsonPropertyName("businessAdministrators"), YamlMember(Order = 5, Alias = "businessAdministrators")]
    public virtual List<PeopleReferenceDefinition>? BusinessAdministrators { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#notification-recipients">notification recipients</see>
    /// </summary>
    [DataMember(Name = "notificationRecipients", Order = 6), JsonPropertyOrder(6), JsonPropertyName("notificationRecipients"), YamlMember(Order = 6, Alias = "notificationRecipients")]
    public virtual List<PeopleReferenceDefinition>? NotificationRecipients { get; set; }

    /// <summary>
    /// Gets/sets an <see cref="List{T}"/> containing the task's <see cref="LogicalPeopleGroupDefinition"/>s
    /// </summary>
    [DataMember(Name = "groups", Order = 7), JsonPropertyOrder(7), JsonPropertyName("groups"), YamlMember(Order = 7, Alias = "groups")]
    public virtual List<LogicalPeopleGroupDefinition>? Groups { get; set; }

}
