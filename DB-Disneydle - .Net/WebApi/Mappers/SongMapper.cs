using BLL.Entities;
using WebApi.Models.Song;

namespace WebApi.Mappers
{
	internal static class SongMapper
	{
		/// <summary>
		/// Convert BLL Song to readable data for API
		/// </summary>
		/// <param name="song">BLL song</param>
		/// <returns>SongDtoGet</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static SongDtoGet ToDtoGet(this BLL.Entities.Song song)
		{
			if(song is null) throw new ArgumentNullException(nameof(song));
			return new SongDtoGet()
			{
				Song_Id = song.Song_Id,
				Title = song.Title,
				Content = song.Content,
				Clip = song.Clip,
			};
		}

		/// <summary>
		/// Convert Api post data to BLL Song
		/// </summary>
		/// <param name="post">SongDtoPost</param>
		/// <returns>Song BLL</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Song ToBLL(this SongDtoPost post)
		{
			if(post is null) throw new ArgumentNullException( nameof(post));
			return new Song(
				0,
				post.Title,
				post.Content,
				post.Clip
				);
		}


		/// <summary>
		/// Convert Api Put data to Bll song
		/// </summary>
		/// <param name="post">SongDtoPut</param>
		/// <returns>BLL Song</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Song ToBLL(this SongDtoPut post)
		{
			if (post is null) throw new ArgumentNullException(nameof(post));
			return new Song(
				0,
				post.Title,
				post.Content,
				post.Clip
				);
		}

	}
}
