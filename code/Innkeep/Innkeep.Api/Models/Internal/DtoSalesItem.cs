﻿using Innkeep.Api.Models.Pretix.Objects.Sales;

namespace Innkeep.Api.Models.Internal;

public class DtoSalesItem
{
	public int Id { get; set; }
	
	public required string Name { get; set; }
	
	public required decimal Price { get; set; }
	
	public required decimal TaxRate { get; set; }
	
	public required string Currency { get; set; }
	
	public int CartCount { get; set; }

	public static DtoSalesItem FromPretix(PretixSalesItem pretixSalesItem)
	{
		return new DtoSalesItem()
		{
			Id = pretixSalesItem.Id,
			Name = pretixSalesItem.Name.German,
			Price = pretixSalesItem.DefaultPrice,
			TaxRate = pretixSalesItem.TaxRate,
			Currency = pretixSalesItem.Currency,
		};
	}
}