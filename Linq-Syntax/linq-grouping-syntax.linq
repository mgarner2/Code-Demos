<Query Kind="Expression">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//single attribute group
from genre in Genres
group genre by genre.Name

//multi attribute group
from track in Tracks
group track by new {track.Genre.Name, track.AlbumId}



//you can save your grouping into a temporary collection for use in further process

// from parent to child
from genre in Genres
group genre by genre.Name into gresults
select new{
	keyValue = gresults.Key,
	tracks = from x in gresults.ToList()
		select new 	{
			song = from y in x.Tracks
				select y.Name
		}
}
//child using parent attribute -- Easier to start from child when grouping
from track in Tracks
group track by track.Genre.Name into gresults
select new {
	keyValue = gresults.Key,
	songs = from x in gresults
		select new {
			song = x.Name,
			title = x.Album.Title
		}
}

//access keyvalue where you have multiple values
from track in Tracks
group track by new {track.Genre.Name, track.AlbumId} into gresults
select new {
	keyvalueGenre = gresults.Key.Name,
	songs = from x in gresults
		select new {
			song = x.Name,
			title = x.Album.Title
		}
}

//grouping can be done on a class (entity) level
from track in Tracks
group track by track.Genre into gresults
select new {
	keyvalueGenre = gresults.Key.Name,
	songs = from x in gresults
		select new {
			song = x.Name,
			title = x.Album.Title
		}
}