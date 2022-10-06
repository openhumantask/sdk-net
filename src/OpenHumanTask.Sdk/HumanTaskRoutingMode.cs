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
    /// Enumerates all supported routing modes for human tasks
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HumanTaskRoutingMode
    {
        /// <summary>
        /// Indicates that the task does not perform any routing.
        /// </summary>
        [EnumMember(Value = "none")]
        None,
        /// <summary>
        /// Indicates that a new subtask will be created and assigned to the first resolved potential owner. 
        /// The runtime will then wait for the subtask's completion, will then assign a new one to the next potential owner, and will finally repeat those steps until all potential owner have performed the task.
        /// </summary>
        [EnumMember(Value = "sequential ")]
        Sequential,
        /// <summary>
        /// Indicates that a subtask will be created for each and every potential owner. The resulting subtasks are performed by their actual owner in parallel.
        /// </summary>
        [EnumMember(Value = "parallel")]
        Parallel
    }

}
