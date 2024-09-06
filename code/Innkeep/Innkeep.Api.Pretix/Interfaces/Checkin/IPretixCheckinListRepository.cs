﻿using Innkeep.Api.Models.Pretix.Objects.Checkin;
using Innkeep.Http.Interfaces;

namespace Innkeep.Api.Pretix.Interfaces.Checkin;

public interface IPretixCheckinListRepository
{
	public Task<IHttpResponse<PretixCheckinList>> GetAll(string organizerSlug, string eventSlug);
}