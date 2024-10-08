﻿using System.Globalization;
using System.Text.Json;
using Innkeep.Server.Services.Legacy.Interfaces.Api;
using Innkeep.Server.Services.Legacy.Interfaces.Db;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Innkeep.Server.Controllers.Legacy.Endpoints.Pretix;

public class PretixRequestController
{
	private readonly IRegisterService _registerService;
	private readonly IPretixService _pretixService;

	public PretixRequestController(IRegisterService registerService, IPretixService pretixService)
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		_registerService = registerService;
		_pretixService = pretixService;
	}

	[Route("Pretix/Organizer/CheckIn/{secret}")]
	public IActionResult CheckIn()
	{
		return new OkObjectResult("Ok");
	}
	
	[Route("Pretix/CheckinLists/{registerId}")]
	public IActionResult GetCheckinLists([FromRoute] string registerId)
	{
		Log.Debug("Received Checkin List Request from Register: {RegisterId}", registerId);
		if (_registerService.CurrentRegistersContains(registerId))
		{
			Log.Debug("Register {RegisterId} found in trusted clients, sending Checkin Lists", registerId);
			return new OkObjectResult(JsonSerializer.Serialize(_pretixService.CheckinLists));
		}

		Log.Debug("Register {RegisterId} not trusted", registerId);
		return new UnauthorizedResult();
	}

	[Route("Pretix/Organizer/{registerId}")]
	public IActionResult GetOrganizer([FromRoute] string registerId)
	{
		Log.Debug("Received Organizer Request from Register: {RegisterId}", registerId);
		if (_registerService.CurrentRegistersContains(registerId))
		{
			Log.Debug("Register {RegisterId} found in trusted clients, sending organizer", registerId);
			return new OkObjectResult(JsonSerializer.Serialize(_pretixService.SelectedOrganizer));
		}

		Log.Debug("Register {RegisterId} not trusted", registerId);
		return new UnauthorizedResult();
	}
	
	[Route("Pretix/Event/{registerId}")]
	public IActionResult GetEvent([FromRoute] string registerId)
	{
		Log.Debug("Received Event Request from Register: {RegisterId}", registerId);
		if (_registerService.CurrentRegistersContains(registerId))
		{
			Log.Debug("Register {RegisterId} found in trusted clients, sending event", registerId);
			return new OkObjectResult(JsonSerializer.Serialize(_pretixService.SelectedEvent));
		}

		Log.Debug("Register {RegisterId} not trusted", registerId);
		return new UnauthorizedResult();
	}
	
	[Route("Pretix/SalesItems/{registerId}")]
	public IActionResult GetSalesItems([FromRoute] string registerId)
	{
		Log.Debug("Received Sales Items Request from Register: {RegisterId}", registerId);
		if (_registerService.CurrentRegistersContains(registerId))
		{
			Log.Debug("Register {RegisterId} found in trusted clients, sending sales items", registerId);
			return new OkObjectResult(JsonSerializer.Serialize(_pretixService.SalesItems));
		}

		Log.Debug("Register {RegisterId} not trusted", registerId);
		return new UnauthorizedResult();
	}
}