<Query Kind="Statements">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//navigation can be used to obtain information from a Parent
var results = from x in Albums
	orderby x.ReleaseYear descending,
			x.ArtistId ascending,
			x.Title ascending
		select new
		{
			Year = x.ReleaseYear,
			Artist = x.Artist.Name,
			Title = x.Title
		};
results.Dump();

var trackresults = from x in Tracks
					where x.Album.Artist.Name.Equals("U2")
					select new
		{
			Song = x.Name,
			Album = x.Album.Title,
			Length = x.Milliseconds / 60000.0
		};
trackresults.Dump();

//.Union()
//Scenario: one cannot get all the data from a single query due to the type of databeing returned
//This could be because of missing collection records or attributes that are null
//The Union needs to ensure cast typing is correct, the number of columns are the same, and cast type matches are identical
//(query1).Union(quert2).Union(queryn).orderby(first sort).thenby(second sort).ThenByDescending(nth sort)

var albumsummary = (from x in Albums
		where x.Tracks.Count() > 0
		select new 
		{
			Title = x.Title,
			Artist = x.Artist.Name,
			TrackCount = x.Tracks.Count(),
			AlbumCost = x.Tracks.Sum(y => y.UnitPrice),
		}).Union(from x in Albums
		where x.Tracks.Count() == 0
		select new 
		{
			Title = x.Title,
			Artist = x.Artist.Name,
			TrackCount = 0,
			AlbumCost = 0.00m
		}).OrderBy(y => y.Artist).ThenByDescending(y => y.AlbumCost);		
albumsummary.Dump();

//sometimes it is easier to develop queries in multiple steps
var trackcount = (from x in MediaTypes
					select x.Tracks.Count()).Max();
trackcount.Dump();
		
var popularMediaType = from x in MediaTypes
						where x.Tracks.Count() >= trackcount
						select new
		{
			type = x.Name,
			tcount = x.Tracks.Count()
		};
popularMediaType.Dump();

var combinedPopularMediaType = from x in MediaTypes
						where x.Tracks.Count() >= (from y in MediaTypes
													select y.Tracks.Count()).Max()
						select new
		{
			type = x.Name,
			tcount = x.Tracks.Count()
		};
combinedPopularMediaType.Dump();

//which artist(s) released the most albums?
//Artist Name, Number of Releases, Name of the Albums

var results = from x in Artists
	where x.Albums.Count() >= (from y in Artists
								select y.Albums.Count()).Max()
	select new
		{
			Name = x.Name,
			Releases = x.Albums.Count(),
			Titles = from y in x.Albums
						select y.Title
		};
results.Dump();
	
var results = from x in Artists
	where x.Albums.Count() >= (from y in Artists
								select y.Albums.Count()).Max()
	select new
		{
			Name = x.Name,
			Releases = x.Albums.Count(),
//			Titles = from y in x.Albums //Query Syntax
//						select y.Title
			Titles = x.Albums.Select(y => y.Title)//Method Syntax
		};
results.Dump();
		
		
		
		
		
		
		