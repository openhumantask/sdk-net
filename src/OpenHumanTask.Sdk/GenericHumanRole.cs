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
/// Enumerates all supported generic human task roles
/// </summary>
[Flags]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GenericHumanRole
{
    /// <summary>
    /// Indicates no role
    /// </summary>
    [EnumMember(Value = "none")]
    None = 0,
    /// <summary>
    /// Indicates the '<see href="https://github.com/openhumantask/specification/blob/main/specification.md#potential-initiators">potentialInitiator</see>' role
    /// </summary>
    [EnumMember(Value = "potentialInitiator")]
    PotentialInitiator = 1,
    /// <summary>
    /// Indicates the '<see href="https://github.com/openhumantask/specification/blob/main/specification.md#initiator">initiator</see>' role
    /// </summary>
    [EnumMember(Value = "potentialInitiator")]
    Initiator = 2,
    /// <summary>
    /// Indicates the '<see href="https://github.com/openhumantask/specification/blob/main/specification.md#potential-owners">potentialOwner</see>' role
    /// </summary>
    [EnumMember(Value = "potentialOwner")]
    PotentialOwner = 4,
    /// <summary>
    /// Indicates the '<see href="https://github.com/openhumantask/specification/blob/main/specification.md#excluded-owners">excludedOwner</see>' role
    /// </summary>
    [EnumMember(Value = "potentialOwner")]
    ExcludedOwner = 8,
    /// <summary>
    /// Indicates the '<see href="https://github.com/openhumantask/specification/blob/main/specification.md#actual-owner">actualOwner</see>' role
    /// </summary>
    [EnumMember(Value = "actualOwner")]
    ActualOwner = 16,
    /// <summary>
    /// Indicates the '<see href="https://github.com/openhumantask/specification/blob/main/specification.md#stakeholders">stakeholder</see>' role
    /// </summary>
    [EnumMember(Value = "stakeholder")]
    Stakeholder = 32,
    /// <summary>
    /// Indicates the '<see href="https://github.com/openhumantask/specification/blob/main/specification.md#business-administrators">businessAdministrator</see>' role
    /// </summary>
    [EnumMember(Value = "businessAdministrator")]
    BusinessAdministrator = 64,
    /// <summary>
    /// Indicates the '<see href="https://github.com/openhumantask/specification/blob/main/specification.md#notification-recipients">notificationRecipient</see>' role
    /// </summary>
    [EnumMember(Value = "businessAdministrator")]
    NotificationRecipient = 128
}
