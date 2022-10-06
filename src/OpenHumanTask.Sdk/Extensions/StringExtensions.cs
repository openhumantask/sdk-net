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

namespace OpenHumanTask.Sdk
{
    /// <summary>
    /// Defines extensions for <see cref="string"/>s
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Determines if the string is a runtime expression.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>A boolean indicating whether or not the string is a runtime expression.</returns>
        public static bool IsRuntimeExpression(this string value)
        {
            if(string.IsNullOrWhiteSpace(value)) return false;
            return value.TrimStart().StartsWith("${") && value.TrimEnd().EndsWith('}');
        }

    }

}
