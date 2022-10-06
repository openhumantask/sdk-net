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

namespace OpenHumanTask.Sdk.Models
{

    /// <summary>
    /// Represents the definition used to configure people assignments for instance of the human task definition.
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#people-assignments-definitions"/></remarks>
    [DataContract]
    public class PeopleAssignmentsDefinition
    {

        /// <summary>
        /// Gets/sets an <see cref="ICollection{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#potential-initiators">potential initiators</see>
        /// </summary>
        [DataMember(Name = "potentialInitiators", Order = 1)]
        [JsonPropertyName("potentialInitiators")]
        public virtual ICollection<PeopleReferenceDefinition>? PotentialInitiators { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="ICollection{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#potential-owners">potential owners</see>
        /// </summary>
        [DataMember(Name = "potentialOwners", Order = 2)]
        [JsonPropertyName("potentialOwners")]
        public virtual ICollection<PeopleReferenceDefinition>? PotentialOwners { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="ICollection{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#excluded-owners">excluded owners</see>
        /// </summary>
        [DataMember(Name = "excludedOwners", Order = 3)]
        [JsonPropertyName("excludedOwners")]
        public virtual ICollection<PeopleReferenceDefinition>? ExcludedOwners { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="ICollection{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#stakeholders">stakeholders</see>
        /// </summary>
        [DataMember(Name = "stakeholders", Order = 4)]
        [JsonPropertyName("stakeholders")]
        public virtual ICollection<PeopleReferenceDefinition>? Stakeholders { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="ICollection{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#business-administrators">business administrators</see>
        /// </summary>
        [DataMember(Name = "businessAdministrators", Order = 5)]
        [JsonPropertyName("businessAdministrators")]
        public virtual ICollection<PeopleReferenceDefinition>? BusinessAdministrators { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="ICollection{T}"/> containing the task's <see href="https://github.com/openhumantask/specification/blob/main/specification.md#notification-recipients">notification recipients</see>
        /// </summary>
        [DataMember(Name = "notificationRecipients", Order = 6)]
        [JsonPropertyName("notificationRecipients")]
        public virtual ICollection<PeopleReferenceDefinition>? NotificationRecipients { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="ICollection{T}"/> containing the task's <see cref="LogicalPeopleGroupDefinition"/>s
        /// </summary>
        [DataMember(Name = "groups", Order = 7)]
        [JsonPropertyName("groups")]
        public virtual ICollection<LogicalPeopleGroupDefinition>? Groups { get; set; }

    }

}
