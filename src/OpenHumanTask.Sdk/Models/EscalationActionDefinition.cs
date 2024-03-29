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
/// Represents the definition of the action undertaken as the result of an escalation.
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#escalation-action-definitions"/></remarks>
[DataContract]
public record EscalationActionDefinition
{

    /// <summary>
    /// Gets/sets an object used to configure the notification to perform as the escalation's effect. Required if <see cref="Reassignment"/> and <see cref="Subtask"/> have not been set, otherwise ignored.
    /// </summary>
    [DataMember(Name = "notification", IsRequired = true, Order = 1), JsonPropertyOrder(1), JsonPropertyName("notification"), YamlMember(Order = 1, Alias = "notification")]
    public virtual NotificationDefinition? Notification { get; set; }

    /// <summary>
    /// Gets/sets an object used to configure the reassignment to perform as the escalation's effect. Required if <see cref="Notification"/> and <see cref="Subtask"/> have not been set, otherwise ignored.
    /// </summary>
    [DataMember(Name = "reassignment", IsRequired = true, Order = 2), JsonPropertyOrder(2), JsonPropertyName("reassignment"), YamlMember(Order = 2, Alias = "reassignment")]
    public virtual ReassignmentDefinition? Reassignment { get; set; }

    /// <summary>
    /// Gets/sets an object used to configure the subtask to perform as the escalation's effect. Required if <see cref="Notification"/> and <see cref="ReassignmentDefinition"/> have not been set, otherwise ignored.
    /// </summary>
    [DataMember(Name = "subtask", IsRequired = true, Order = 3), JsonPropertyOrder(3), JsonPropertyName("subtask"), YamlMember(Order = 3, Alias = "subtask")]
    public virtual SubtaskDefinition? Subtask { get; set; }

}
