<Query Kind="Statements">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var results = from x in Albums
	select new {
		title = x.Title,
		decade = x.ReleaseYear > 1969 && x.ReleaseYear < 1980?"70s":
				 x.ReleaseYear > 1979 && x.ReleaseYear < 1990?"80s":
				 x.ReleaseYear > 1989 && x.ReleaseYear < 2000?"90s":
				 "Modern"
	};
	results.Dump();

var trackavg = (from x in Tracks
					select x.Milliseconds).Average();
var trackbalance = from x in Tracks

	select new {
		song = x.Name,
		length = 	x.Milliseconds > trackavg? "Long":
					x.Milliseconds < trackavg? "Short" :
												"Average"
	};
	trackbalance.Dump();