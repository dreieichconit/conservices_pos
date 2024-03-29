﻿using Innkeep.Server.Data.Context;
using Innkeep.Server.Data.Interfaces.ApplicationSettings;
using Innkeep.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Innkeep.Server.Data.Repositories.ApplicationSettings;

public class ApplicationSettingsRepository : BaseRepository<ApplicationSetting>, IApplicationSettingsRepository
{
	public ApplicationSetting GetSetting()
	{
		using var db = InnkeepServerContext.Create();

		var item = db.ApplicationSettings.Include(x => x.SelectedEvent).Include(x => x.SelectedOrganizer).FirstOrDefault();
		if (item is not null) return item;
		
		Create(new ApplicationSetting());

		return db.ApplicationSettings.Include(x => x.SelectedEvent).Include(x => x.SelectedOrganizer).FirstOrDefault()!;
	}

	public bool SaveSetting(ApplicationSetting setting)
	{
		using var db = InnkeepServerContext.Create();

		var fromDb = db.ApplicationSettings.First();
		
		db.ChangeTracker.Clear();

		db.Update(fromDb);
		db.Attach(setting.SelectedOrganizer);
		db.Attach(setting.SelectedEvent);

		fromDb.OrganizerInfo = setting.OrganizerInfo;
		fromDb.SelectedEvent = setting.SelectedEvent;
		fromDb.SelectedOrganizer = setting.SelectedOrganizer;

		return TrySave(db);
	}
}