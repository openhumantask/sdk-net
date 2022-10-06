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
    /// Enumerates all support rendering modes for views
    /// </summary>
    [Flags]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ViewRenderingMode
    {
        /// <summary>
        /// Indicates that no processing should be performed, and that the template should be served raw.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,
        /// <summary>
        /// Indicates the default rendering mode. The raw template is pre-processed in search of runtime expressions it interpolates after evaluation.
        /// </summary>
        [EnumMember(Value = "process")]
        Process = 1,
        /// <summary>
        /// Indicates that the template should be pre-rendered by the server before being served to consumers.
        /// </summary>
        [EnumMember(Value = "render")]
        Render = 2
    }

}
