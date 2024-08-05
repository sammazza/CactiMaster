SELECT Persons.fname, Cities.CityName
FROM Cities INNER JOIN Persons ON Cities.[Id] = Persons.[cityiD];
