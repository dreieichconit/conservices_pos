﻿namespace Innkeep.Server.Data.Models;

public class Event
{
	public int Id { get; set; }
	
	public Organizer Organizer { get; set; } = null!;
	
	public string Name { get; set; } = null!;

	public string Slug { get; set; } = null!;
}