SELECT * FROM usersTbl

SELECT * FROM usersTbl order by prefix

SELECT uName, lName, phone FROM usersTbl WHERE gender = 'M'

SELECT * FROM usersTbl WHERE city = 'Haifa'

SELECT * FROM usersTbl

SELECT * FROM usersTbl WHERE city = 'Haifa' OR city = 'Jerusalem'

SELECT * FROM usersTbl WHERE city LIKE '%el%'

SELECT * FROM usersTbl WHERE city IN ('Haifa', 'Tel-Aviv', 'Jerusalem')

SELECT * FROM usersTbl WHERE yearBorn >= 2003 AND yearBorn <= 2004

SELECT * FROM usersTbl WHERE yearBorn BETWEEN 2003 AND 2004

SELECT * FROM usersTbl WHERE gender = 'M' and email LIKE '%gmail%'