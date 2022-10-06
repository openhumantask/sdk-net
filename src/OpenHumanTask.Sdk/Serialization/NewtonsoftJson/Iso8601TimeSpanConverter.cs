﻿/*
 * Copyright 2021-Present The Serverless Workflow Specification Authors
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System.Xml;

namespace Newtonsoft.Json.Converters
{

    /// <summary>
    /// Represents the <see cref="JsonConverter"/> used to convert from and to ISO 8601 timespan expressions
    /// </summary>
    public class Iso8601TimeSpanConverter
        : JsonConverter<TimeSpan>
    {

        /// <inheritdoc/>
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var expression = reader.Value?.ToString();
            if (string.IsNullOrWhiteSpace(expression))
                return default;
            return Iso8601TimeSpan.Parse(expression);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            writer.WriteValue(XmlConvert.ToString(value));
        }

    }

}
