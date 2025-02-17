using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
	internal static class Mapper
	{
		/// <summary>
		/// We convert Sql data to DAL Character data
		/// </summary>
		/// <param name="record">IDataRecord</param>
		/// <returns>DAL.Entities.Character</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Character ToCharacter(this IDataRecord record)
		{
			if(record is null) throw new ArgumentNullException(nameof(record));

			return new Character()
			{
				Character_Id = (int)record[nameof(Character.Character_Id)],
				Name = (string)record[nameof(Character.Name)],
				ClothingColor = (string)record[nameof(Character.ClothingColor)],
				Role = (string)record[nameof(Character.Role)],
				Gender = (string)record[nameof(Character.Gender)],
				Type = (string)record[nameof(Character.Type)],
				ParutionYear = (short)record[nameof(Character.ParutionYear)],
				HairColor = (string)record[nameof(Character.HairColor)],
				Continent = (string)record[nameof(Character.Continent)],
			};
		}


		/// <summary>
		/// We convert Sql data to DAL Quote data
		/// </summary>
		/// <param name="record">IDataRecord object</param>
		/// <returns>DAL.Entities.Quote</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Quote ToQuote(this IDataRecord record)
		{
			if (record is null) throw new ArgumentNullException(nameof(record));

			/*For debug
			for (int i = 0; i < record.FieldCount; i++)
			{
				Console.WriteLine(record.GetName(i));
			}*/

			return new Quote()
			{
				Quote_Id = (int)record[nameof(Quote.Quote_Id)],
				Language = (string)record[nameof(Quote.Language)],
				Content = (string)record[nameof(Quote.Content)],
				Character_Id = (record[nameof(Quote.Character_Id)] is DBNull)? null: (int)record[nameof(Quote.Character_Id)],
				Clip = (record[nameof(Quote.Clip)] is DBNull)? null : (string)record[nameof(Quote.Clip)]
			};
		}

		public static Song ToSong(this IDataRecord record)
		{
			if(record is null) throw new ArgumentNullException(nameof (record));

			return new Song() 
			{ 
				Song_Id = (int)record[nameof (Song.Song_Id)],
				Title = (string)record[nameof(Song.Title)],
				Content = (record[nameof(Song.Content)] is DBNull)? null : (byte[])record[nameof(Song.Content)],
				Clip = (record[nameof(Song.Clip)] is DBNull)? null : (string)record[nameof(Song.Clip)],
			};
		}
	}
}
