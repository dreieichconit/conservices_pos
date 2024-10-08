﻿using System.Text.Json.Serialization;

namespace Innkeep.Api.Models.Fiskaly.Request.Auth;

// ReSharper disable UnusedAutoPropertyAccessor.Global
public class FiskalyAdminAuth
{
	[JsonPropertyName("admin_pin")]
	public required string AdminPin { get; set; }
}