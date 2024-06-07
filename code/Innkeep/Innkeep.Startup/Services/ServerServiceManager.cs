﻿using Innkeep.Api.Auth;
using Innkeep.Api.Interfaces.Repository.Auth;
using Innkeep.Api.Pretix.Interfaces;
using Innkeep.Api.Pretix.Repositories.Auth;
using Innkeep.Api.Pretix.Repositories.General;
using Innkeep.Api.Pretix.Repositories.Sales;
using Innkeep.Db.Interfaces;
using Innkeep.Server.Db.Context;
using Innkeep.Server.Db.Models;
using Innkeep.Server.Db.Repositories.Config;
using Innkeep.Server.Services.Authentication;
using Innkeep.Server.Services.Database;
using Innkeep.Server.Services.Interfaces;
using Innkeep.Server.Services.Pretix;
using Innkeep.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Innkeep.Startup.Services;

public static class ServerServiceManager
{
	public static void ConfigureServices(IServiceCollection collection)
	{
		ConfigureDatabase(collection);
		ConfigureDbRepositories(collection);
		ConfigureDbServices(collection);
		ConfigureHttpRepositories(collection);
		ConfigureHttpServices(collection);
	}

	private static void ConfigureDatabase(IServiceCollection collection)
	{
		if (!Directory.Exists("./db")) 
			Directory.CreateDirectory("./db");
		
		collection.AddDbContextFactory<InnkeepServerContext>(options => options.UseSqlite("DataSource=./db/server.db"));
		collection.AddDbContext<InnkeepServerContext>();
	}

	private static void ConfigureDbRepositories(IServiceCollection collection)
	{
		collection.AddSingleton<IDbRepository<PretixConfig>, PretixConfigRepository>();
	}
	
	private static void ConfigureDbServices(IServiceCollection collection)
	{
		collection.AddSingleton<IPretixAuthenticationService, PretixAuthenticationService>();
		collection.AddSingleton<IDbService<PretixConfig>, PretixConfigService>();
	}

	private static void ConfigureHttpRepositories(IServiceCollection collection)
	{
		collection.AddSingleton<IPretixAuthRepository, PretixAuthRepository>();
		collection.AddSingleton<IPretixOrganizerRepository, PretixOrganizerRepository>();
		collection.AddSingleton<IPretixEventRepository, PretixEventRepository>();
		collection.AddSingleton<IPretixSalesItemRepository, PretixSalesItemRepository>();
	}

	private static void ConfigureHttpServices(IServiceCollection collection)
	{
		collection.AddSingleton<IPretixSalesItemService, PretixSalesItemService>();
	}
}