using System;
using System.Collections.Generic;

namespace Data
{
	public class TableEntity
	{
		private int tableID;
		private List<PlayerEntity> players { get; set; }
		private float pot;
		private Deck deck;
		// database for deck http://stackoverflow.com/questions/5666307/whats-the-best-way-to-store-a-deck-of-cards-in-database

		setPot(float p)
		{
			pot = p;
		}
	}
}
