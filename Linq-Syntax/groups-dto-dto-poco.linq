<Query Kind="Program">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	var results = from x in Genres
	select new GenreDTO
	{
		genre = x.Name,
		albums = from y in x.Tracks
		group y by y.Album into grp //.Album is the Key attribute group
		select new AlbumDTO
		{
			title = grp.Key.Title,
			year = grp.Key.ReleaseYear,
			tracks = grp.Count(),
			songs = from z in grp
			select new TrackPOCO
			{
				song = z.Name,
				milliseconds = z.Milliseconds
			}
		}
	};
	results.Dump();
}

// Define other methods and classes here

public class GenreDTO
{
	public string genre {get;set;}
	public IEnumerable<AlbumDTO> albums {get;set;}
}
public class AlbumDTO
{
	public string title {get;set;}
	public int year {get;set;}
	public int tracks {get;set;}
	public IEnumerable<TrackPOCO> songs {get;set;}
}
public class TrackPOCO
{
	public string song {get;set;}
	public int milliseconds {get;set;}
	public string length //Read-only property: Calculated value
	{
		get
		{
			int minutes = milliseconds/60000;
			int seconds = (milliseconds % 60000) / 1000;
			return string.Format("{0}:{1:00}",minutes,seconds);
		}
	}
}
