﻿using Demolite.Http.Interfaces;
using Demolite.Http.Response;
using Innkeep.Api.Endpoints.Server;
using Innkeep.Api.Internal.Interfaces.Server.Register;
using Innkeep.Api.Internal.Repositories.Server.Core;
using Innkeep.Api.Models.General;
using Innkeep.Api.Models.Internal.Register;
using Innkeep.Db.Client.Models;
using Innkeep.Services.Interfaces;
using Serilog;

namespace Innkeep.Api.Internal.Repositories.Server.Register;

public class RegisterConnectionRepository(IDbService<ClientConfig> clientConfigService)
	: AbstractServerRepository(clientConfigService), IRegisterConnectionRepository
{
	protected override int Timeout => 500;

	public async Task<IHttpResponse<bool>> Test()
		=> await TryTest(await GetAddress());

	public async Task<IHttpResponse<bool>> Connect(string identifier, string description, string hostName)
	{
		var serverAddress = await GetAddress();
		var uri = ServerUrlBuilder.Endpoints.Address(serverAddress).Register.Connect;

		var payload = new ConnectionRequest
		{
			Identifier = identifier,
			Description = description,
			HostName = hostName,
		};

		var responseContent = string.Empty;

		try
		{
			var result = await Post<ConnectionRequest, Empty>(uri, payload);
			responseContent = result.Content;
			return HttpResponse<bool>.FromResult(result, _ => result.IsSuccess);
		}
		catch (Exception ex)
		{
			return HttpResponse<bool>.Exception(ex, responseContent, false);
		}
	}

	public async Task<IHttpResponse<bool>> Discover(string address)
		=> await TryTest(address);

	private async Task<IHttpResponse<bool>> TryTest(string address)
	{
		var resultText = string.Empty;

		try
		{
			var uri = ServerUrlBuilder.Endpoints.Address(address).Register.Discover;
			var result = await Get<Empty>(uri);
			resultText = result.Content;
			return HttpResponse<bool>.FromResult(result, _ => result.IsSuccess);
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Exception during Server connection Test");
			return HttpResponse<bool>.Exception(ex, resultText, false);
		}
	}
}