﻿using Demolite.Http.Interfaces;
using Innkeep.Api.Models.Fiskaly.Objects.Transaction;
using Innkeep.Api.Models.Fiskaly.Request.Transaction;

namespace Innkeep.Api.Fiskaly.Interfaces.Transaction;

public interface IFiskalyTransactionRepository
{
	public Task<IHttpResponse<FiskalyTransaction>> StartTransaction(
		string tssId,
		string transactionId,
		string clientId
	);

	public Task<IHttpResponse<FiskalyTransaction>> UpdateTransaction(FiskalyTransactionUpdateRequest updateRequest);
}