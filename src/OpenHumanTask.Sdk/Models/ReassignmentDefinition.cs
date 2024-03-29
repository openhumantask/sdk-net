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
/// Represents an object used to define and configure a task's reassignment.
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#reassignment-definitions"/></remarks>
[DataContract]
public record ReassignmentDefinition
{

    /// <summary>
    /// Gets/sets the <see cref="PeopleReferenceDefinition"/> used to configure the people to reassign the task to. If not set, releases the task to be claimed by one of its potential owners.
    /// </summary>
    [DataMember(Name = "to", Order = 1), JsonPropertyOrder(1), JsonPropertyName("to"), YamlMember(Order = 1, Alias = "to")]
    public virtual PeopleReferenceDefinition? To { get; set; }

}
