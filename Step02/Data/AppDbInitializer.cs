using eTickets.Models;
using eTickets.Data.Enums;

namespace eTickets.Data
{
    // Burası fake/dummy data üretecek

    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope= applicationBuilder.ApplicationServices.CreateScope()) // Kapsam belirliyor
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // Önceki adımlarda vt yi boş da olsa yaratmış olduk.

                context.Database.EnsureCreated(); // VT var mı/ yok mu

                //Cinema tablosu için
                if (!context.Cinemas.Any()) // içinde kayıt var/yok
                {
                    // eğer kayıt yoksa buraya düşecek o yüzden !(not) operatörünü koyduk
                    // Yeni bazı kayıtlar bölümü

                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        // 1.Kayıt
                        new Cinema()
                        {
                            Name="Cinema 1",
                            Logo="http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description="Burası Cinema 1 için bir açıklamadır."
                        },

                        new Cinema()
                        {
                            Name="Cinema 2",
                            Logo="http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description="Burası Cinema 2 için bir açıklamadır."
                        },
                        new Cinema()
                        {
                            Name="Cinema 3",
                            Logo="http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description="Burası Cinema 3 için bir açıklamadır."
                        },
                        new Cinema()
                        {
                            Name="Cinema 4",
                            Logo="http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description="Burası Cinema 4 için bir açıklamadır."
                        },
                        new Cinema()
                        {
                            Name="Cinema 5",
                            Logo="http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description="Burası Cinema 5 için bir açıklamadır."
                        }
                    });

                    context.SaveChanges(); // Yukarda girdiğim bilgiler VT deki Cinemas tablosuna yazılacak.


                }

                //Actor tablosu için
                if (!context.Actors.Any()) // içinde kayıt var/yok
                {
                    // eğer kayıt yoksa buraya düşecek o yüzden !(not) operatörünü koyduk
                    // Yeni bazı kayıtlar bölümü

                    context.Actors.AddRange(new List<Actor>()
                    {
                        // 1.Kayıt
                        new Actor()
                        {
                            FullName="Actor 1",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-1.jpeg",
                            Bio="Burası Actor 1 için bir bio dur."
                        },
                        new Actor()
                        {
                            FullName="Actor 2",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-2.jpeg",
                            Bio="Burası Actor 2 için bir bio dur."
                        },
                        new Actor()
                        {
                            FullName="Actor 3",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-3.jpeg",
                            Bio="Burası Actor 3 için bir bio dur."
                        },
                        new Actor()
                        {
                            FullName="Actor 4",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-4.jpeg",
                            Bio="Burası Actor 4 için bir bio dur."
                        },
                        new Actor()
                        {
                            FullName="Actor 5",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-5.jpeg",
                            Bio="Burası Actor 5 için bir bio dur."
                        }

                    });

                    context.SaveChanges(); // Yukarda girdiğim bilgiler VT deki Actors tablosuna yazılacak.


                }

                //Producer tablosu için
                if (!context.Producers.Any()) // içinde kayıt var/yok
                {
                    // eğer kayıt yoksa buraya düşecek o yüzden !(not) operatörünü koyduk
                    // Yeni bazı kayıtlar bölümü

                    context.Producers.AddRange(new List<Producer>()
                    {
                        // 1.Kayıt
                        new Producer()
                        {
                            FullName="Producer 1",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-1.jpeg",
                            Bio="Burası Producer 1 için bir bio dur."
                        },
                        new Producer()
                        {
                            FullName="Producer 2",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-2.jpeg",
                            Bio="Burası Producer 2 için bir bio dur."
                        },
                        new Producer()
                        {
                            FullName="Producer 3",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-3.jpeg",
                            Bio="Burası Producer 3 için bir bio dur."
                        },
                        new Producer()
                        {
                            FullName="Producer 4",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-4.jpeg",
                            Bio="Burası Producer 4 için bir bio dur."
                        },
                        new Producer()
                        {
                            FullName="Producer 5",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-5.jpeg",
                            Bio="Burası Producer 5 için bir bio dur."
                        }

                    });

                    context.SaveChanges(); // Yukarda girdiğim bilgiler VT deki Producers tablosuna yazılacak.


                }

                //Movie tablosu için
                if (!context.Movies.Any()) // içinde kayıt var/yok
                {
                    // eğer kayıt yoksa buraya düşecek o yüzden !(not) operatörünü koyduk
                    // Yeni bazı kayıtlar bölümü

                    context.Movies.AddRange(new List<Movie>()
                    {
                        // 1.Kayıt
                        new Movie()
                        {
                            Name = "Life",
                            Description="Bu Life filmidir",
                            Price=40,
                            ImageURL="http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate=DateTime.Now.AddDays(-10), // Bulunduğumuz günden 10 gün öncesi
                            EndDate=DateTime.Now.AddDays(20), // Bulunduğumuz günden 20 gün sonrası
                            CinemaId=3,
                            ProducerId=3,
                            MovieCategory=MovieCategory.Action

                        },
                        // 2.Kayıt
                        new Movie()
                        {
                            Name = "The Shawnshank Redemption",
                            Description="Bu Esaretin Bedeli filmidir",
                            Price=60,
                            ImageURL="http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate=DateTime.Now, 
                            EndDate=DateTime.Now.AddDays(3),
                            CinemaId=1,
                            ProducerId=1,
                            MovieCategory=MovieCategory.Drama
                        },
                        // 3.Kayıt
                        new Movie()
                        {
                            Name = "Ghost",
                            Description="Bu Ghost filmidir",
                            Price=39.5,
                            ImageURL="http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(7),
                            CinemaId=4,
                            ProducerId=4,
                            MovieCategory=MovieCategory.Drama

                        },
                        // 4.Kayıt
                        new Movie()
                        {
                            Name = "Race",
                            Description="Bu Race filmidir",
                            Price=35.5,
                            ImageURL="http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate=DateTime.Now.AddDays(-10), // Bulunduğumuz günden 10 gün öncesi
                            EndDate=DateTime.Now.AddDays(-5), // Bulunduğumuz günden 20 gün sonrası
                            CinemaId=1,
                            ProducerId=2,
                            MovieCategory=MovieCategory.Action

                        },
                        // 5.Kayıt
                        new Movie()
                        {
                            Name = "Cold Souls",
                            Description="Bu Cold Soles filmidir",
                            Price=38.5,
                            ImageURL="http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate=DateTime.Now.AddDays(3), // Bulunduğumuz günden 10 gün öncesi
                            EndDate=DateTime.Now.AddDays(20), // Bulunduğumuz günden 20 gün sonrası
                            CinemaId=1,
                            ProducerId=3,
                            MovieCategory=MovieCategory.Horror

                        },
                        // 6.Kayıt
                        new Movie()
                        {
                            Name = "Scooby Doo",
                            Description="Bu Scooby Doo filmidir",
                            Price=25,
                            ImageURL="http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate=DateTime.Now.AddDays(-10), // Bulunduğumuz günden 10 gün öncesi
                            EndDate=DateTime.Now.AddDays(-2), // Bulunduğumuz günden 20 gün sonrası
                            CinemaId=1,
                            ProducerId=3,
                            MovieCategory=MovieCategory.Cartoon

                        }

                    });

                    context.SaveChanges(); // Yukarda girdiğim bilgiler VT deki Producers tablosuna yazılacak.


                }

                //Actors-Movies tablosu için
                if (!context.Actors_Movies.Any()) // içinde kayıt var/yok
                {
                    // eğer kayıt yoksa buraya düşecek o yüzden !(not) operatörünü koyduk
                    // Yeni bazı kayıtlar bölümü

                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        // 1.Kayıt
                        new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId=1
                        },
                        new Actor_Movie()
                        {
                            ActorId=3,
                            MovieId=1
                        },
                        new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId=2
                        },
                        new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId=2
                        },
                        new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId=3
                        },
                        new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId=3
                        },
                        new Actor_Movie()
                        {
                            ActorId=5,
                            MovieId=3
                        },
                        new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId=4
                        },
                        new Actor_Movie()
                        {
                            ActorId=3,
                            MovieId=4
                        },
                        new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId=4
                        },
                        new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId=5
                        },
                        new Actor_Movie()
                        {
                            ActorId=3,
                            MovieId=5
                        },
                        new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId=5
                        },
                        new Actor_Movie()
                        {
                            ActorId=5,
                            MovieId=5
                        },
                        new Actor_Movie()
                        {
                            ActorId=3,
                            MovieId=6
                        },
                        new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId=6
                        },
                        new Actor_Movie()
                        {
                            ActorId=5,
                            MovieId=6
                        }
                    });

                    context.SaveChanges(); // Yukarda girdiğim bilgiler VT deki Producers tablosuna yazılacak.


                }

            }




        }
    }
}
