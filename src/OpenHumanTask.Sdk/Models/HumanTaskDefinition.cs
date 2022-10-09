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

namespace OpenHumanTask.Sdk.Models
{

    /// <summary>
    /// Represents the <see href="https://github.com/openhumantask/specification/blob/main/specification.md#human-task-definitions">definition of a human task.</see>
    /// </summary>
    /// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#human-task-definitions"/></remarks>
    [DataContract]
    public class HumanTaskDefinition
        : IIdentifiable<string>
    {

        /// <summary>
        /// Gets/sets a string that globally and uniquely identifies the <see cref="HumanTaskDefinition"/>. 
        /// <para/>MUST be lowercase and must only contain alphanumeric characters, with the exception of the.and - characters.
        /// <para/>It is recommended for the id to be automatically generated by implementations, following the {namespace}.{name}:{version}format.
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        [JsonPropertyName("id")]
        public virtual string Id { get; set; } = null!;

        [YamlIgnore]
        object IIdentifiable.Id => this.Id;

        /// <summary>
        /// Gets/sets the name of the <see cref="HumanTaskDefinition"/>.
        /// <para/>Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.*
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        [JsonPropertyName("name")]
        public virtual string Name { get; set; } = null!;

        /// <summary>
        /// Gets/sets the namespace of the <see cref="HumanTaskDefinition"/>. Namespaces are used to organise definitions in a logical group.
        /// <para/>Must be lowercase and only contain alphanumeric characters, with the exceptions of the '-' character.
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "namespace", IsRequired = true, Order = 3)]
        [JsonPropertyName("namespace")]
        public virtual string Namespace { get; set; } = null!;

        /// <summary>
        /// Gets/sets the <see cref="HumanTaskDefinition"/>'s <see href="https://semver.org/">semantic version</see>.
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "version", IsRequired = true, Order = 4)]
        [JsonPropertyName("version")]
        public virtual string Version { get; set; } = null!;

        /// <summary>
        /// Gets the <see cref="HumanTaskDefinition"/>'s full name
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]
        [YamlIgnore]
        public virtual string? FullName => string.IsNullOrWhiteSpace(this.Namespace) | string.IsNullOrWhiteSpace(this.Name) | string.IsNullOrWhiteSpace(this.Version) ? null : $"{this.Namespace}.{this.Name}:{this.Version}";

        /// <summary>
        /// Gets/sets the <see href="https://semver.org/">semantic version</see> of the Open Human Task specification the <see cref="HumanTaskDefinition"/> uses.
        /// </summary>
        [Required, MinLength(3)]
        [DataMember(Name = "specVersion", IsRequired = true, Order = 5)]
        [JsonPropertyName("specVersion")]
        public virtual string SpecVersion { get; set; } = "0.1.0";

        /// <summary>
        /// Gets/sets the <see cref="HumanTaskRoutingMode"/>. Defaults to <see cref="HumanTaskRoutingMode.None"/>
        /// </summary>
        [Required, DefaultValue(HumanTaskRoutingMode.None)]
        [DataMember(Name = "routingMode", IsRequired = true, Order = 6)]
        [JsonPropertyName("routingMode")]
        public virtual HumanTaskRoutingMode RoutingMode { get; set; } = HumanTaskRoutingMode.None;

        /// <summary>
        /// Gets/sets the language of the runtime expressions used in the <see cref="HumanTaskDefinition"/>. Defaults to 'jq'.
        /// </summary>
        [Required, MinLength(2), DefaultValue("jq")]
        [DataMember(Name = "expressionLanguage", IsRequired = true, Order = 7)]
        [JsonPropertyName("expressionLanguage")]
        public virtual string ExpressionLanguage { get; set; } = "jq";

        /// <summary>
        /// Gets/sets a literal or a runtime expression used to generate the keys of instanciated human tasks. It could be used, in the case of a purchase review, to set the reviewed purchase order's id as the human task's key.
        /// </summary>
        [DataMember(Name = "key", Order = 8)]
        [JsonPropertyName("key")]
        public virtual string? Key { get; set; }

        /// <summary>
        /// Gets a boolean indicating whether or not instances of the <see cref="HumanTaskDefinition"/> can be skipped
        /// </summary>
        [DataMember(Name = "skipable", Order = 9)]
        [JsonPropertyName("skipable")]
        public virtual bool Skipable { get; set; } = false;

        /// <summary>
        /// Gets/sets an object containing the <see cref="HumanTaskDefinition"/>'s localized titles, mapped by two-letter ISO 639-1 language name. If a string, the culture-invariant title's value. If an object, the mappings of localized titles to their two-letter ISO 639-1 language names. Supports runtime expression.
        /// </summary>
        [DataMember(Name = "title", Order = 10)]
        [JsonPropertyName("title")]
        public virtual object? Title { get; set; }

        /// <summary>
        /// Gets/sets an object containing the <see cref="HumanTaskDefinition"/>'s localized subjects, mapped by two-letter ISO 639-1 language name. If a string, the culture-invariant subject's value. If an object, the mappings of localized subjects to their two-letter ISO 639-1 language names. Supports runtime expression.
        /// </summary>
        [DataMember(Name = "subject", Order = 11)]
        [JsonPropertyName("subject")]
        public virtual object? Subject { get; set; }

        /// <summary>
        /// Gets/sets an object containing the <see cref="HumanTaskDefinition"/>'s localized descriptions, mapped by two-letter ISO 639-1 language name. If a string, the culture-invariant description's value. If an object, the mappings of localized descriptions to their two-letter ISO 639-1 language names. Supports runtime expression.
        /// </summary>
        [DataMember(Name = "description", Order = 12)]
        [JsonPropertyName("description")]
        public virtual object? Description { get; set; }

        /// <summary>
        /// Gets/sets the <see cref="PeopleAssignmentsDefinition"/> used to configure the people assigned to the task as well as their respective roles.
        /// </summary>
        [DataMember(Name = "peopleAssignments", Order = 13)]
        [JsonPropertyName("peopleAssignments")]
        public virtual PeopleAssignmentsDefinition? PeopleAssignments { get; set; }

        /// <summary>
        /// Gets/sets an object used to configure the task's input data.
        /// </summary>
        [DataMember(Name = "inputData", Order = 14)]
        [JsonPropertyName("inputData")]
        public virtual DataModelDefinition? InputData { get; set; }

        /// <summary>
        /// Gets/sets an object used to configure the task's output data.
        /// </summary>
        [DataMember(Name = "outputData", Order = 15)]
        [JsonPropertyName("outputData")]
        public virtual DataModelDefinition? OutputData { get; set; }

        /// <summary>
        /// Gets/sets the definition of the forms that will be presented to users when performing instances of the <see cref="HumanTaskDefinition"/>.
        /// </summary>
        [DataMember(Name = "form", Order = 16)]
        [JsonPropertyName("form")]
        public virtual FormDefinition? Form { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="List{T}"/> containing the subtasks the <see cref="HumanTaskDefinition"/> is made out of.
        /// </summary>
        [DataMember(Name = "subtasks", Order = 17)]
        [JsonPropertyName("subtasks")]
        public virtual List<SubtaskDefinition>? Subtasks { get; set; }

        /// <summary>
        /// Gets/sets the way subtasks should be executed.
        /// </summary>
        [DefaultValue(SubtaskExecutionMode.Sequential)]
        [DataMember(Name = "subtaskExecutionMode", Order = 18)]
        [JsonPropertyName("subtaskExecutionMode")]
        public virtual SubtaskExecutionMode SubtaskExecutionMode { get; set; } = SubtaskExecutionMode.Sequential;

        /// <summary>
        /// Gets/sets an <see cref="List{T}"/> containing the <see cref="HumanTaskDefinition"/>'s <see cref="DeadlineDefinition"/>s.
        /// </summary>
        [DataMember(Name = "deadlines", Order = 19)]
        [JsonPropertyName("deadlines")]
        public virtual List<DeadlineDefinition>? Deadlines { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="List{T}"/> containing the <see cref="HumanTaskDefinition"/>'s <see cref="CompletionBehaviorDefinition"/>s.
        /// </summary>
        [DataMember(Name = "completionBehaviors", Order = 20)]
        [JsonPropertyName("completionBehaviors")]
        public virtual List<CompletionBehaviorDefinition>? CompletionBehaviors { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="List{T}"/> containing the definitions of the task's possible outcomes.
        /// </summary>
        [DataMember(Name = "outcomes", Order = 21)]
        [JsonPropertyName("outcomes")]
        public virtual List<OutcomeDefinition>? Outcomes { get; set; }

        /// <summary>
        /// Gets/sets an <see cref="IDictionary{TKey, TValue}"/> containg key/value pairs of helpful terms used to describe the human task intended purpose, subject areas, or other important qualities.
        /// </summary>
        [DataMember(Name = "annotations", Order = 22)]
        [JsonPropertyName("annotations")]
        public virtual Dictionary<string, string>? Annotations { get; set; }

        /// <summary>
        /// Gets/sets an object used to provide additional unstructured information about the human task definition. May be used by implementations to define additional functionality.
        /// </summary>
        [DataMember(Name = "metadata", Order = 23)]
        [JsonPropertyName("metadata")]
        public virtual object? Metadata { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.FullName!;
        }

        /// <summary>
        /// Builds a new <see cref="HumanTaskDefinition"/>'s unique identifier, according to the format recommended by the OHT spec ({namespace}.{name}:{version}).
        /// </summary>
        /// <param name="name">The name of the <see cref="HumanTaskDefinition"/> to build a unique identifier for.</param>
        /// <param name="namespace">The namespace of the <see cref="HumanTaskDefinition"/> to build a unique identifier for.</param>
        /// <param name="version">The version of the <see cref="HumanTaskDefinition"/> to build a unique identifier for.</param>
        /// <returns>A new <see cref="HumanTaskDefinition"/>'s unique identifier.</returns>
        public static string BuildId(string name, string @namespace, string version)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
            return $"{@namespace}.{name}:{version}";
        }

    }

}
