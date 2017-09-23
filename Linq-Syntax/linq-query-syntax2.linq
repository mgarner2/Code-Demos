<Query Kind="Expression">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from a in Artists
where a.Albums.Count()> 3
orderby a.Albums.Count() descending, a.Name ascending
select new
	{
		Arist = a.Name,
		Albums = a.Albums.Count(),
		Collection = from b in 	a.Albums
						select new 
							{
								Title = b.Title,
								Year = b.ReleaseYear
							}
		
	}