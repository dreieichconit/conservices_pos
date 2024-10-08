﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Innkeep.Api.Json;

public class FiskalyDateTimeJsonConverter : JsonConverter<DateTime>
{
	public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var input = reader.GetInt64();
		return ParseInput(input);
	}

	public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(ParseOutput(value));
	}
	
	public static DateTime ParseInput(long? input)
	{
		return input is null ? DateTime.Now : DateTimeOffset.FromUnixTimeSeconds(input.Value).DateTime.ToLocalTime();
	}

	public static long ParseOutput(DateTime input)
	{
		return new DateTimeOffset(input).ToUnixTimeSeconds();
	}
}