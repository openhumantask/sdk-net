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

using Semver;

namespace OpenHumanTask.Sdk;

/// <summary>
/// Defines helpers to handle semantic versions
/// </summary>
public static class SemanticVersion
{

    /// <summary>
    /// Parse the specified input into a new <see cref="SemVersion"/>.
    /// </summary>
    /// <param name="input">The input to parse.</param>
    /// <returns>The parsed <see cref="SemVersion"/>.</returns>
    public static SemVersion Parse(string input)
    {
        if(string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(nameof(input));
        return SemVersion.Parse(input, SemVersionStyles.Strict);
    }

    /// <summary>
    /// Attempts to parse the specified input into a new <see cref="SemVersion"/>
    /// </summary>
    /// <param name="input">The input to parse.</param>
    /// <param name="version">The parsed <see cref="SemVersion"/>, if any.</param>
    /// <returns>A boolean indicating whether or not the specified input could be parsed.</returns>
    public static bool TryParse(string input, out SemVersion? version)
    {
        version = default;
        try
        {
            version = Parse(input);
            return version == default;
        }
        catch
        {
            return false;
        }
    }

}
