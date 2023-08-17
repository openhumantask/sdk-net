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
/// Represents a reference to a <see cref="HumanTaskDefinition"/>.
/// </summary>
/// <remarks>See <see href="https://github.com/openhumantask/specification/blob/main/specification.md#task-definition-references"/></remarks>
[DataContract]
public record HumanTaskDefinitionReference
{

    /// <summary>
    /// Gets/sets the name of the referenced <see cref="HumanTaskDefinition"/>.
    /// </summary>
    [Required, MinLength(3)]
    [DataMember(Name = "name", IsRequired = true, Order = 1), JsonPropertyOrder(1), JsonPropertyName("name"), YamlMember(Order = 1, Alias = "name")]
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Gets/sets the namespace the referenced <see cref="HumanTaskDefinition"/> belongs to.
    /// </summary>
    [Required, MinLength(3)]
    [DataMember(Name = "namespace", IsRequired = true, Order = 2), JsonPropertyOrder(2), JsonPropertyName("namespace"), YamlMember(Order = 2, Alias = "namespace")]
    public virtual string Namespace { get; set; } = null!;

    /// <summary>
    /// Gets/sets the <see href="">semantic version</see> of the referenced <see cref="HumanTaskDefinition"/>.
    /// </summary>
    [DefaultValue("latest")]
    [DataMember(Name = "version", Order = 3), JsonPropertyOrder(3), JsonPropertyName("version"), YamlMember(Order = 3, Alias = "version")]
    public virtual string? Version { get; set; } = null!;

    /// <inheritdoc/>
    public override string ToString()
    {
        var fullName = $"{this.Namespace}.{this.Name}";
        if (!string.IsNullOrWhiteSpace(this.Version)) fullName += $":{this.Version}";
        return fullName;
    }

    /// <summary>
    /// Parses the specified input into a new <see cref="HumanTaskDefinitionReference"/>
    /// </summary>
    /// <param name="input">The input to parse</param>
    /// <returns>A new <see cref="HumanTaskDefinitionReference"/>.</returns>
    public static HumanTaskDefinitionReference? Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return default;
        var components = input.Split('.', StringSplitOptions.RemoveEmptyEntries);
        if (components.Length < 2) throw new Exception($"The specified input '{input}' is not a valid task definition reference.");
        var @namespace = components[0];
        var name = components[1];
        var version = components.Length == 3 ? components[2] : null;
        return new() { Name = name, Namespace = @namespace, Version = version };
    }

    /// <summary>
    /// Attempts to parse the specified input into a new <see cref="HumanTaskDefinitionReference"/>
    /// </summary>
    /// <param name="input">The input to parse</param>
    /// <param name="reference">The resulting <see cref="HumanTaskDefinitionReference"/>, if any</param>
    /// <returns>A boolean indicating whether or not the specified input could be parsed into a new <see cref="HumanTaskDefinitionReference"/></returns>
    public static bool TryParse(string input, out HumanTaskDefinitionReference? reference)
    {
        reference = default;
        try
        {
            reference = Parse(input);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Implicitly converts the specified string into a new <see cref="HumanTaskDefinitionReference"/>
    /// </summary>
    /// <param name="input">The input to parse</param>
    public static implicit operator HumanTaskDefinitionReference?(string input) => Parse(input);

    /// <summary>
    /// Implicitly converts the specified <see cref="HumanTaskDefinitionReference"/> into its string representation.
    /// </summary>
    /// <param name="reference">The <see cref="HumanTaskDefinitionReference"/> to convert.</param>
    /// <returns>The specified <see cref="HumanTaskDefinitionReference"/>'s string representation.</returns>
    public static implicit operator string?(HumanTaskDefinitionReference? reference) => reference?.ToString();

}
