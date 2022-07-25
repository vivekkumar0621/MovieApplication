# MovieApplication

I am using Asp.Net Core for creating web api.
using ADO.Net for database connectivity.
Using MySQL as Database Engine





endpoint and their sample output:
1. Home Page
  Controller : HomeController
  Endpoint : https://localhost:44371/api/Home/GetMovies
  
  Sample Output: 
          [ {
              "movieName": "Planet Hulk",
              "dateOfRelease": "2010-02-02",
              "actorsName": [ "Alphachino","Ben Affeck"],
              "producerName": "Asim Nath",
              "plot": "when the hulk become too dangerous",
              "poster": { "posterID": 1,"posterName": "Poster1","posterLocation": "D:\\Git Project\\Poster" }
    },
    {
        "movieName": "Finding Hulk Hogan",
        "dateOfRelease": "2010-11-17",
        "actorsName": [ "Brad Pit","Robert Downy" ],
        "producerName": "Asim Nath",
        "plot": "One sided examination of fall and rise",
        "poster": { "posterID": 2,"posterName": "Poster2", "posterLocation": "D:\\Git Project\\Poster" }
    }]
    
2. Add Movie
  Controller : MovieController
  Endpoint : https://localhost:44371/api/Movie/AddMovie
  
  Sample Output: 
        {
            "mid": 11,
            "movieName": "WWE : The Under Taker 3",
            "plot": "Dead Man 3",
            "dateOfRelease": "2006-10-17",
            "pid": 1,
            "posterID": 100
        }
        
        
3. Edit Movie
    Controller : MovieController
    Endpoint : https://localhost:44371/api/Movie/EditMovie
    Sample Output:
        {
            "mid": 11,
            "movieName": "WWE : The Under Taker 3",
            "plot": "Dead Man Return",
            "dateOfRelease": "2006-10-17",
            "pid": 1,
            "posterID": 100
        }
    
4. Add Actor
    Controller : ActorController
    EndPoint : https://localhost:44371/api/Actor/AddActor
    Sample Input:
        {
          "ActorName":"SRK2",
          "Bio":"Iconic of India2",
          "DOB":"12-08-1978",
          "Gender":"Male"
        }
    Sample Output:
         7
  
5.Add Producer
    Controller : ProducerController
    Endpoint : https://localhost:44371/api/Producer/AddProducer
    Sample Input:
        {
          "ProducerName":"Karan Johar 3",
          "Bio": "top leading producer 3",
          "DOB": "12-09-1965",
          "Company": "Dharma Production 2",
          "Gender": "Male"
        }
    Sample Output:
        4
    
  
 6. Get Actor Detail for Dropdown
      Endpoint : https://localhost:44371/api/Movie/GetActors
      Sample Output : [
          "Alphachino",
          "Ben Affeck",
          "Brad Pit",
          "Robert Downy",
          "Christan Belly",
          "SRK"
      ]
      
7. Get Producer Detail for Dropdown
    Endpoint : https://localhost:44371/api/Movie/GetProducers
    Sample Output : 
          [
            "Asim Nath",
            "Karan Johar",
            "Karan Johar 2"
        ]
