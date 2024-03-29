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

namespace OpenHumanTask.Sdk;

/// <summary>
/// Enumerates all support execution modes for subtasks
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubtaskExecutionMode
{
    /// <summary>
    /// Indicates that subtasks are executed in lexical order.
    /// </summary>
    [EnumMember(Value = "sequential")]
    Sequential,
    /// <summary>
    /// Indicates that subtasks are executed in parallel.
    /// </summary>
    [EnumMember(Value = "parallel")]
    Parallel
}
