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
    /// Enumerates all support types of completion behaviors
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CompletionBehaviorType
    {
        /// <summary>
        /// Indicates that the task completes a soon as the condition matches.
        /// </summary>
        [EnumMember(Value = "automatic")]
        Automatic,
        /// <summary>
        /// Indicates that the task must be explicitly completed by the actual owner whern the condition matches.
        /// </summary>
        [EnumMember(Value = "manual")]
        Manual
    }

}
