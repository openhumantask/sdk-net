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

using System.Dynamic;
using System.Text.Json;

namespace OpenHumanTask.Sdk;

/// <summary>
/// Defines extensions for <see cref="JsonElement"/>s
/// </summary>
public static class JsonElementExtensions
{

    /// <summary>
    /// Deserializes the <see cref="JsonElement"/> into a new object.
    /// </summary>
    /// <param name="element">The <see cref="JsonElement"/> to deserialize.</param>
    /// <returns>The deserialized <see cref="JsonElement"/>.</returns>
    public static object? ToObject(this JsonElement element)
    {
        var t = element.GetType();
        return element.ValueKind switch
        {
            JsonValueKind.Undefined => null,
            JsonValueKind.Object => element.UnwrapObject(),
            JsonValueKind.Array => element.UnwrapArray(),
            JsonValueKind.String => element.GetString(),
            JsonValueKind.Number => element.GetInt64(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null,
            _ => throw new NotSupportedException($"The specified {nameof(JsonValueKind)} '{element.ValueKind}' is not supported.")
        };
    }

        private static object? UnwrapObject(this JsonElement element)
        {
            var deserialized = System.Text.Json.JsonSerializer.Deserialize<IDictionary<string, JsonElement>>(element)!;
            var unwrapped = (IDictionary<string, object?>)new ExpandoObject();
            foreach (var kvp in deserialized)
            {
                unwrapped.Add(kvp.Key, kvp.Value.ToObject());
            }
            return unwrapped;
        }

    private static object? UnwrapArray(this JsonElement element)
    {
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<List<JsonElement>>(element)!;
        var unwrapped = new List<object>(deserialized.Count);
        foreach (var jsonElement in deserialized)
        {
            unwrapped.Add(jsonElement.ToObject()!);
        }
        return unwrapped;
    }

}
